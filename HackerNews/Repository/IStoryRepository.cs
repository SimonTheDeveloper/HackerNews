using System.Collections.Generic;
using HackerNews.Model;

namespace HackerNews.Repository
{
    public interface IStoryRepository
    {
        /// <summary>
        /// Gets the best story ids.
        /// </summary>
        /// <param name="number">The number of story ids.</param>
        /// <returns></returns>
        IEnumerable<int> GetBestStoryIds(int number);
        Story GetStory(int id);
    }
}