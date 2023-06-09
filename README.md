# HackernewsNet
A wrapper for the hackernews api (https://news.ycombinator.com), to get the stories, links and more

## Technologies

### Created using
- .NET Core 6.0

### NuGet/Dependencies used
- Newtonsoft.Json

## Features

### Nuget
- https://www.nuget.org/packages/HackernewsNet

### General
- Through methods, like ```GetNewStories()```, ```GetTopStories()``` and ```GetBestStories()``` you get Id-Lists, containing the stories
- Through methods, like ```GetNewStoriesWithDetails()```, ```GetTopStoriesWithDetails()``` and ```GetBestStoriesWithDetails()``` you get Story-lists, which contain the stories and their data

## Usage

## Example

```
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
```

## FAQ

#### Do I need an API-Key?

I'm citing the HackerNews-GitHub account here "There is currently no rate limit." - https://github.com/HackerNews/API#uri-and-versioning

#### What do I have to be aware of?

Currently this wrapper does not differentiate between Stories, Jobs, Polls or anything, 
I will implement this but for now theoretically a story under New, Top or Best could also 
be a poll or job-posting rather than an story and therefore the data might not be accurate.

## License

**Software:** HackernewsNet

The api and data belongs to YCombinator! - liebki (me) or this project isn’t endorsed by YCombinator and doesn’t reflect the views or opinions of YCombinator or anyone officially involved in managing it.

[GNU](https://choosealicense.com/licenses/gpl-3.0/)

## Roadmap

- Implement Job-postings, polls, ask- and show-stories etc.
- There are a few things to implement, before this wrapper is complete..