using System.Collections.Generic;
using HackerNews.Model;

namespace HackerNews.Repository
{
    public interface IJsonReader
    {
        /// <summary>
        /// Gets the ids from the best stories json file.
        /// </summary>
        /// <returns>IEnumerable<int> of the story ids</int></returns>
        IEnumerable<int> GetBestStoriesIds();

        /// <summary>
        /// Gets the story from the specified json file.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Story instance</returns>
        Story GetStory(int id);
    }
}