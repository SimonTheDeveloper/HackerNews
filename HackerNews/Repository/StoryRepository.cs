using System;
using System.Collections.Generic;
using System.Linq;
using HackerNews.Model;
using Microsoft.Extensions.Configuration;

namespace HackerNews.Repository
{
    public class StoryRepository : IStoryRepository
    {
        private readonly IJsonReader _reader;
        private readonly IConfiguration _configuration;

        public StoryRepository(IJsonReader reader, IConfiguration configuration)
        {
            _reader = reader;
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the best story ids.
        /// </summary>
        /// <param name="number">The number of ids to be returned.</param>
        /// <returns></returns>
        public IEnumerable<int> GetBestStoryIds(int number)
        {
            if (MemoryCacheProvider.GetValue("Ids") is IEnumerable<int> storyIds)
            {
                return storyIds;
            }

            int numberOfStories = Convert.ToInt32(_configuration["NumberOfStories"]);
            storyIds = _reader.GetBestStoriesIds().Take(numberOfStories);
            int cacheIdsMinutes = Convert.ToInt32(_configuration["CacheIdsMinutes"]);
            MemoryCacheProvider.Add("Ids", storyIds, DateTime.Now.AddMinutes(cacheIdsMinutes));
            return storyIds;
        }

        /// <summary>
        /// Gets the story.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Story GetStory(int id)
        {
            if (MemoryCacheProvider.GetValue(id.ToString()) is Story story)
            {
                return story;
            }

            story = _reader.GetStory(id);
            int cacheStoriesInDays = Convert.ToInt32(_configuration["CacheStoriesInDays"]);
            MemoryCacheProvider.Add(id.ToString(), story, DateTime.Now.AddDays(cacheStoriesInDays));
            return story;
        }
    }
}
