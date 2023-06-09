using Newtonsoft.Json;
using HackernewsNet.Models;

namespace HackernewsNet
{
    internal class HackernewsManager
    {
        protected HackernewsManager()
        { }

        private const string HackernewsFirebaseUrl = "https://hacker-news.firebaseio.com/v0/";

        internal static async Task<List<long>> GetStories(int maxItems, StoryType storyType)
        {
            string storyQueryType;
            if (storyType == StoryType.New)
            {
                storyQueryType = "newstories";
            }
            else if (storyType == StoryType.Top)
            {
                storyQueryType = "topstories";
            }
            else
            {
                storyQueryType = "beststories";
            }

            string RawgRequestUrl = $"{HackernewsFirebaseUrl}{storyQueryType}.json";
            string WebResponseAsJson = string.Empty;

            using (HttpClient Client = new())
            {
                Task<HttpResponseMessage> TaskResponse = Client.GetAsync(RawgRequestUrl);
                WebResponseAsJson = await TaskResponse.Result.Content.ReadAsStringAsync();
            }

            List<long> Stories = Json2Object<List<long>>(WebResponseAsJson);
            if (Stories.Count > maxItems)
            {
                Stories.RemoveRange(maxItems, Stories.Count - maxItems);
            }

            return Stories;
        }

        internal static async Task<Story> GetStoryDetails(long itemId)
        {
            string RawgRequestUrl = $"{HackernewsFirebaseUrl}item/{itemId}.json";
            string WebResponseAsJson = string.Empty;

            using (HttpClient Client = new())
            {
                Task<HttpResponseMessage> TaskResponse = Client.GetAsync(RawgRequestUrl);
                WebResponseAsJson = await TaskResponse.Result.Content.ReadAsStringAsync();
            }

            return Json2Object<Story>(WebResponseAsJson);
        }

        internal static async Task<List<Story>> GetStoriesWithDetails(StoryType storyType, int maxItems = 10)
        {
            List<long> StoriesIdList = await GetStories(maxItems, storyType);
            List<Story> StoryList = new();

            foreach (long itemId in StoriesIdList)
            {
                Story item = await GetStoryDetails(itemId);
                if (item != null)
                {
                    StoryList.Add(item);
                }
            }

            return StoryList;
        }

        private static T Json2Object<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}