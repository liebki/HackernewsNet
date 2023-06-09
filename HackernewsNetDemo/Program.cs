using HackernewsNet;
using HackernewsNet.Models;

namespace HackernewsNetDemo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            HackernewsClient hnc = new();

            /*
             * Get the New-, Top- and Beststories as Id-Lists, you can then use GetNewStoryDetails,
             * GetTopStoryDetails or GetBestStoryDetails to get the data of certain stories
            */
            List<long> NewStories = await hnc.GetNewStories();
            List<long> TopStories = await hnc.GetTopStories();
            List<long> BestStories = await hnc.GetBestStories();

            /*
             * But you can also use GetNewStoriesWithDetails, GetTopStoriesWithDetails or
             * GetBestStoriesWithDetails to get stories as Story-Lists containing everything
             * Also using the TimeAsDate-method, you can get the Unixtime converted to a DateTime-object
            */
            List<Story> NewStoriesWithDetails = await hnc.GetNewStoriesWithDetails();
            Console.WriteLine($"New-DateTime: {NewStoriesWithDetails[0].TimeAsDate().ToString("dd.MM.yyyy HH:mm")}");

            List<Story> TopStoriesWithDetails = await hnc.GetTopStoriesWithDetails();
            Console.WriteLine($"Top-DateTime: {TopStoriesWithDetails[0].TimeAsDate().ToString("dd.MM.yyyy HH:mm")}");

            List<Story> BestStoriesWithDetails = await hnc.GetBestStoriesWithDetails();
            Console.WriteLine($"Best-DateTime: {BestStoriesWithDetails[0].TimeAsDate().ToString("dd.MM.yyyy HH:mm")}");

            Console.WriteLine("\nTop-Stories:");
            TopStoriesWithDetails.ForEach(stt => Console.WriteLine($"{stt}\n"));

            Console.WriteLine("\nNew-Stories:");
            NewStoriesWithDetails.ForEach(stn => Console.WriteLine($"{stn}\n"));

            Console.WriteLine("\nBest-Stories:");
            BestStoriesWithDetails.ForEach(stb => Console.WriteLine($"{stb}\n"));
        }
    }
}