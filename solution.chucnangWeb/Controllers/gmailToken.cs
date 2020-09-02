using Newtonsoft.Json;

namespace solution.chucnangWeb.Controllers
{
    public class gmailToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long exprires_in { get; set; }
        public string id_token { get; set; }
    }
    public class userprofile
    {
        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string email { get; set; }
        public string picture { get; set; }
    }
}