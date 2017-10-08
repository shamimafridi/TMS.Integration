using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Integration.Services.CustomerService
{
   public class CustomerService:ICustomerService
    {
        public  async Task<AuthResponse> AsyncSetter()
        {
            try
            {
                //https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
                // New code:
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:3000/");
                client.DefaultRequestHeaders.Accept.Clear();
              //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyIkX18iOnsic3RyaWN0TW9kZSI6dHJ1ZSwic2VsZWN0ZWQiOnt9LCJnZXR0ZXJzIjp7fSwiX2lkIjoiNTljN2UzZWRkZDE5MDYxYzI0YjdhOWFjIiwid2FzUG9wdWxhdGVkIjpmYWxzZSwiYWN0aXZlUGF0aHMiOnsicGF0aHMiOnsibG9naW5fYXR0ZW1wdHMiOiJpbml0IiwidXNlcm5hbWUiOiJpbml0IiwidmVyaWZpZWQiOiJpbml0Iiwic3RhdHMuZGVsZXRlZCI6ImluaXQiLCJhY2NvdW50IjoiaW5pdCIsIl9fdiI6ImluaXQiLCJzdGF0cy51cGRhdGVkX2F0IjoiaW5pdCIsInN0YXRzLmNyZWF0ZWRfYnkiOiJpbml0Iiwic3RhdHMudXBkYXRlZF9ieSI6ImluaXQiLCJzdGF0cy5jcmVhdGVkX2F0IjoiaW5pdCIsInBhc3N3b3JkIjoiaW5pdCIsIl9pZCI6ImluaXQifSwic3RhdGVzIjp7Imlnbm9yZSI6e30sImRlZmF1bHQiOnt9LCJpbml0Ijp7ImFjY291bnQiOnRydWUsIl9fdiI6dHJ1ZSwibG9naW5fYXR0ZW1wdHMiOnRydWUsInZlcmlmaWVkIjp0cnVlLCJzdGF0cy5kZWxldGVkIjp0cnVlLCJzdGF0cy51cGRhdGVkX2F0Ijp0cnVlLCJzdGF0cy5jcmVhdGVkX2J5Ijp0cnVlLCJzdGF0cy51cGRhdGVkX2J5Ijp0cnVlLCJzdGF0cy5jcmVhdGVkX2F0Ijp0cnVlLCJ1c2VybmFtZSI6dHJ1ZSwicGFzc3dvcmQiOnRydWUsIl9pZCI6dHJ1ZX0sIm1vZGlmeSI6e30sInJlcXVpcmUiOnt9fSwic3RhdGVOYW1lcyI6WyJyZXF1aXJlIiwibW9kaWZ5IiwiaW5pdCIsImRlZmF1bHQiLCJpZ25vcmUiXX0sInBhdGhzVG9TY29wZXMiOnt9LCJlbWl0dGVyIjp7ImRvbWFpbiI6bnVsbCwiX2V2ZW50cyI6e30sIl9ldmVudHNDb3VudCI6MCwiX21heExpc3RlbmVycyI6MH19LCJpc05ldyI6ZmFsc2UsIl9kb2MiOnsibG9naW5fYXR0ZW1wdHMiOjMsInZlcmlmaWVkIjpmYWxzZSwiYXZhdGFyIjp7fSwic3RhdHMiOnsiZGVsZXRlZCI6ZmFsc2UsInVwZGF0ZWRfYXQiOiIyMDE3LTA5LTI0VDE2OjU3OjE3LjMwMloiLCJjcmVhdGVkX2J5IjoiMSIsInVwZGF0ZWRfYnkiOiIxIiwiY3JlYXRlZF9hdCI6IjIwMTctMDktMjRUMTY6NTc6MTcuMzAyWiJ9LCJhY2NvdW50IjoiNTljN2UzZWRkZDE5MDYxYzI0YjdhOWFkIiwiX192IjowLCJ1c2VybmFtZSI6Im5vb3IiLCJwYXNzd29yZCI6IiQyYSQxMCQ3NTVneTY5TXZDaW9SRmtUOEdMb3NPRVBNclV6NXJwUTNmdmdBaUczeHltQ3R0cFFsT2hDNiIsIl9pZCI6IjU5YzdlM2VkZGQxOTA2MWMyNGI3YTlhYyJ9LCIkaW5pdCI6dHJ1ZSwiaWF0IjoxNTA2MjgzNDM3fQ.luKQ7UA8JRFrWoi5cUsz-mn1fKEI5Wz0HFR0cxhT_h0");
                client.DefaultRequestHeaders.Add("subdomain", "azam");

                var user = new User { username = "shamim", password = "password" };
                var response =  client.PostAsJsonAsync("api/login", user).Result;
                response.EnsureSuccessStatusCode();
                var contents = await response.Content.ReadAsAsync<AuthResponse>();
                // Return the URI of the created resource.
                return contents;

                //using (var db= new TMS.Integration.Storage.TMSEntities())
                //{

                //}
            }catch(Exception ex)
            {
                throw ex;
            }

        }
        public class AuthResponse
        {
            public string token { set; get; }
            public User user { set; get; }
        }
        public class User
        {
            public string username { get; set; }
            public string password { get; set; }

        }
    }
}
