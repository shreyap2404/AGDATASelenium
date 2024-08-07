using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace TestProject1
{
    public class Tests
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
        };


        [SetUp]
        public void Setup()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Test]
        public async Task GetPosts_ShouldReturnSuccessAndPosts()
        {
            var response = await Client.GetAsync("posts");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }

        // POST https://jsonplaceholder.typicode.com/posts
        [Test]
        public async Task PostPost_ShouldReturnSuccess()
        {
            var postData = new
            {
                userId = 1,
                title = "foo",
                body = "bar"
            };
            var content = new StringContent(JObject.FromObject(postData).ToString(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("posts", content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseBody.Contains("foo"));
        }

        // PUT https://jsonplaceholder.typicode.com/posts/{postId}
        [Test]
        public async Task PutPost_ShouldReturnSuccess()
        {
            var postId = 1;
            var putData = new
            {
                id = postId,
                userId = 1,
                title = "foo",
                body = "bar updated"
            };
            var content = new StringContent(JObject.FromObject(putData).ToString(), Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"posts/{postId}", content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseBody.Contains("bar updated"));
        }

        // DELETE https://jsonplaceholder.typicode.com/posts/{postId}
        [Test]
        public async Task DeletePost_ShouldReturnSuccess()
        {
            var postId = 1;
            var response = await Client.DeleteAsync($"posts/{postId}");
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        // POST https://jsonplaceholder.typicode.com/posts/{postId}/comments
        [Test]
        public async Task PostComment_ShouldReturnSuccess()
        {
            var postId = 1;
            var commentData = new
            {
                postId = postId,
                name = "foo",
                email = "bar@example.com",
                body = "baz"
            };
            var content = new StringContent(JObject.FromObject(commentData).ToString(), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync($"posts/{postId}/comments", content);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseBody.Contains("baz"));
        }

        // GET https://jsonplaceholder.typicode.com/comments?postId={postId}
        [Test]
        public async Task GetComments_ShouldReturnSuccess()
        {
            var postId = 1;
            var response = await Client.GetAsync($"comments?postId={postId}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }
    }
}