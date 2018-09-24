using Enterprise_App.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Enterprise_App.Net
{
    public class DataRetriever
    {
        public DataRetriever()
        {

        }
        public async Task<List<Post>> GetPosts()
        {
            List<Post> posts = new List<Post>();

            using (WebClient wc = new WebClient())
            {
                string json = await wc.DownloadStringTaskAsync("https://jsonplaceholder.typicode.com/posts");

                if (!string.IsNullOrEmpty(json))
                {
                    //deserialize JSON objects to C# objects
                    posts = JsonConvert.DeserializeObject<Post[]>(json).ToList();
                }
            }

            return posts;
        }

        public async Task<List<Comment>> GetComments(int id)
        {
            List<Comment> comments = new List<Comment>();

            using (WebClient wc = new WebClient())
            {
                string json = await wc.DownloadStringTaskAsync("https://jsonplaceholder.typicode.com/posts/" + id + "/comments");

                if (!string.IsNullOrEmpty(json))
                {
                    comments = JsonConvert.DeserializeObject<Comment[]>(json).ToList();
                }
            }

            return comments;
        }

        public User GetUser(int userId)
        {
            User user = new User();

            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString("https://jsonplaceholder.typicode.com/users/" + userId);

                if (!string.IsNullOrEmpty(json))
                {
                    user = JsonConvert.DeserializeObject<User>(json);
                }
            }

            return user;
        }
    }
}
