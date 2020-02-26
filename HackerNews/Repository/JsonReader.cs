using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HackerNews.Model;
using Microsoft.Extensions.Configuration;

namespace HackerNews.Repository
{
    /// <summary>
    /// Class to read from json files.
    /// </summary>
    public class JsonReader : IJsonReader
    {
        private readonly IConfiguration _configuration;

        public JsonReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Gets the ids from the best stories json file.
        /// </summary>
        /// <returns> IEnumerable of the story ids</returns>
        public IEnumerable<int> GetBestStoriesIds()
        {
            string fileName = @_configuration["BestStoriesFileName"];
            WebClient client = new WebClient();
            Stream stream =  client.OpenRead(fileName);
            if (stream == null)
            {
                return null;
            }
            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                List<int> items = JsonConvert.DeserializeObject<List<int>>(json);
                return items;
            }
        }

        /// <summary>
        /// Gets the story from the specified json file.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Story instance</returns>
        public Story GetStory(int id)
        {
            string fileName = string.Format(@_configuration["StoryFileName"],id);
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(fileName);
            if (stream == null)
            {
                return null;
            }
            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                Story story = JsonConvert.DeserializeObject<Story>(json);
                return story;
            }
        }
    }
}
