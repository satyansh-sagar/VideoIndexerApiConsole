using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoIndexerAPI
{

    public class JsonSerializer
    {
        public string accountId { get; set; }
        public string id { get; set; }
        public string partition { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string userName { get; set; }
        public DateTime createTime { get; set; }
        public string organization { get; set; }
        public string privacyMode { get; set; }
        public string state { get; set; } 
        public bool isOwned { get; set; }
        public bool isEditable { get; set; }
        public bool isBase { get; set; }
        public int durationInSeconds { get; set; }
        public Summarizedinsights summarizedInsights { get; set; }
        public Breakdown[] breakdowns { get; set; }
        public Social social { get; set; }
    }

    public class Summarizedinsights
    {
        public string name { get; set; }
        public string shortId { get; set; }
        public int privacyMode { get; set; }
        public Duration duration { get; set; }
        public string thumbnailUrl { get; set; }
        public object[] faces { get; set; }
        public Topic[] topics { get; set; }
        public Sentiment[] sentiments { get; set; }
        public Audioeffect[] audioEffects { get; set; }
        public Annotation[] annotations { get; set; }
    }

    public class Duration
    {
        public string time { get; set; }
        public float seconds { get; set; }
    }

    public class Topic
    {
        public string name { get; set; }
        public Appearance[] appearances { get; set; }
        public bool isTranscript { get; set; }
        public int id { get; set; }
    }

    public class Appearance
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public float startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Sentiment
    {
        public string sentimentKey { get; set; }
        public Appearance1[] appearances { get; set; }
        public float seenDurationRatio { get; set; }
    }

    public class Appearance1
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public float startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Audioeffect
    {
        public string audioEffectKey { get; set; }
        public Appearance2[] appearances { get; set; }
        public float seenDurationRatio { get; set; }
        public float seenDuration { get; set; }
    }

    public class Appearance2
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public float startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Annotation
    {
        public string name { get; set; }
        public Appearance3[] appearances { get; set; }
    }

    public class Appearance3
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public float startSeconds { get; set; }
        public float endSeconds { get; set; }
    }

    public class Social
    {
        public bool likedByUser { get; set; }
        public int likes { get; set; }
        public int views { get; set; }
    }

    public class Breakdown
    {
        public string accountId { get; set; }
        public string id { get; set; }
        public string state { get; set; }
        public string processingProgress { get; set; }
        public string failureCode { get; set; }
        public string failureMessage { get; set; }
        public object externalId { get; set; }
        public object externalUrl { get; set; }
        public object metadata { get; set; }
        public Insights insights { get; set; }
        public string thumbnailUrl { get; set; }
        public string publishedUrl { get; set; }
        public string viewToken { get; set; }
        public string sourceLanguage { get; set; }
        public string language { get; set; }
    }

    public class Insights
    {
        public Transcriptblock[] transcriptBlocks { get; set; }
        public Topic1[] topics { get; set; }
        public object[] faces { get; set; }
        public Participant[] participants { get; set; }
        public Contentmoderation contentModeration { get; set; }
        public Audioeffectscategory[] audioEffectsCategories { get; set; }
    }

    public class Contentmoderation
    {
        public float adultClassifierValue { get; set; }
        public int bannedWordsCount { get; set; }
        public float bannedWordsRatio { get; set; }
        public bool isSuspectedAsAdult { get; set; }
        public bool isAdult { get; set; }
    }

    public class Transcriptblock
    {
        public int id { get; set; }
        public Line[] lines { get; set; }
        public object[] sentimentIds { get; set; }
        public object[] thumbnailsIds { get; set; }
        public float sentiment { get; set; }
        public object[] faces { get; set; }
        public Ocr[] ocrs { get; set; }
        public Audioeffectinstance[] audioEffectInstances { get; set; }
        public Scene[] scenes { get; set; }
        public Annotation1[] annotations { get; set; }
    }

    public class Line
    {
        public int id { get; set; }
        public Timerange timeRange { get; set; }
        public Adjustedtimerange adjustedTimeRange { get; set; }
        public int participantId { get; set; }
        public string text { get; set; }
        public bool isIncluded { get; set; }
        public float confidence { get; set; }
    }

    public class Timerange
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Adjustedtimerange
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Ocr
    {
        public Timerange1 timeRange { get; set; }
        public Adjustedtimerange1 adjustedTimeRange { get; set; }
        public Line1[] lines { get; set; }
    }

    public class Timerange1
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Adjustedtimerange1
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Line1
    {
        public int id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string language { get; set; }
        public string textData { get; set; }
        public float confidence { get; set; }
    }

    public class Audioeffectinstance
    {
        public int type { get; set; }
        public Range[] ranges { get; set; }
    }

    public class Range
    {
        public int type { get; set; }
        public Timerange2 timeRange { get; set; }
    }

    public class Timerange2
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Scene
    {
        public int id { get; set; }
        public Timerange3 timeRange { get; set; }
        public string keyFrame { get; set; }
        public Shot[] shots { get; set; }
    }

    public class Timerange3
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Shot
    {
        public int id { get; set; }
        public Timerange4 timeRange { get; set; }
        public string keyFrame { get; set; }
    }

    public class Timerange4
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Annotation1
    {
        public string name { get; set; }
        public Timerange5[] timeRanges { get; set; }
        public Adjustedtimerange2[] adjustedTimeRanges { get; set; }
    }

    public class Timerange5
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Adjustedtimerange2
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Topic1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string stem { get; set; }
        public string[] words { get; set; }
        public float rank { get; set; }
    }

    public class Participant
    {
        public int id { get; set; }
        public string name { get; set; }
        public object pictureUrl { get; set; }
    }

    public class Audioeffectscategory
    {
        public int type { get; set; }
        public string key { get; set; }
    }

}
