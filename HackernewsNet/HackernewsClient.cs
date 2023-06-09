using HackernewsNet.Models;

namespace HackernewsNet
{
    public class HackernewsClient
    {
        public async Task<List<long>> GetNewStories(int maxItems = 10)
        {
            return await HackernewsManager.GetStories(maxItems, StoryType.New);
        }

        public async Task<List<Story>> GetNewStoriesWithDetails(int maxItems = 10)
        {
            return await HackernewsManager.GetStoriesWithDetails(StoryType.New, maxItems);
        }

        public async Task<List<long>> GetTopStories(int maxItems = 10)
        {
            return await HackernewsManager.GetStories(maxItems, StoryType.Top);
        }

        public async Task<List<Story>> GetTopStoriesWithDetails(int maxItems = 10)
        {
            return await HackernewsManager.GetStoriesWithDetails(StoryType.Top, maxItems);
        }

        public async Task<List<long>> GetBestStories(int maxItems = 10)
        {
            return await HackernewsManager.GetStories(maxItems, StoryType.Best);
        }

        public async Task<List<Story>> GetBestStoriesWithDetails(int maxItems = 10)
        {
            return await HackernewsManager.GetStoriesWithDetails(StoryType.Best, maxItems);
        }

        public async Task<Story> GetStoryDetails(long itemId)
        {
            return await HackernewsManager.GetStoryDetails(itemId);
        }
    }
}