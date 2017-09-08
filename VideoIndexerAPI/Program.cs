

///Author : Satyansh Sagar(satyansh.sagar@outlook.com)
///Date : 06-02-2017
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoIndexerAPI
{
    class Program
    {
        

        static void Main(string[] args)
        {
            indexer();
            Console.WriteLine("press 'Enter' to Exit");
            Console.ReadLine();
        }
        /// <summary>
        /// 
        /// </summary>
        private static void indexer()
        {
            var key = "Add Your Key Here";
            var apiUrl = "https://videobreakdown.azure-api.net/Breakdowns/Api/Partner/Breakdowns";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);

            var videoPath = @"D:\test1.mp4";//Your local video path(mp4)
            
            var content = new MultipartFormDataContent();
            //content.Add(new StreamContent(File.Open(videoPath, FileMode.Open)), "Video", "Video");

            content.Add(new StreamContent(File.Open(videoPath, FileMode.Open)));

            Console.WriteLine("Uploading...");
            var result = client.PostAsync(apiUrl + "?name=some_name&description=some_description&privacy=private&partition=some_partition", content).Result;
            var json = result.Content.ReadAsStringAsync().Result;

            Console.WriteLine();
            Console.WriteLine("Uploaded:");
            Console.WriteLine(json);

            var id = JsonConvert.DeserializeObject<string>(json);
            
            while (true)
            {
                Thread.Sleep(10000);

                result = client.GetAsync(string.Format(apiUrl + "/{0}/State", id)).Result;
                json = result.Content.ReadAsStringAsync().Result;

                Console.WriteLine();
                Console.WriteLine("State:");
                Console.WriteLine(json);

                dynamic state = JsonConvert.DeserializeObject(json);
                if (state.state != "Uploaded" && state.state != "Processing")
                {
                    break;
                }
            }

                      

            result = client.GetAsync(string.Format(apiUrl + "/{0}", id)).Result;
            var jsonRes = result.Content.ReadAsStringAsync().Result;
            var replyMsg = JsonConvert.DeserializeObject<JsonSerializer>(jsonRes);


            foreach (var i in replyMsg.breakdowns) 
            {
                foreach(var j in i.insights.transcriptBlocks)
                {
                    Console.WriteLine("Sentiment : "+j.sentiment);
                    foreach(var k in j.lines)
                    {
                        Console.WriteLine(k.text);
                    }
                }
            }
        }
    }
}
