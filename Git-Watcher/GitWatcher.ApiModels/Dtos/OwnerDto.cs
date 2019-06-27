using Newtonsoft.Json;

namespace Git_Watcher_Client.Dto
{
    public class OwnerDto
    {
        public OwnerDto(int id, string login)
        {
            Id = id;
            Login = login;
        }

        /// <summary>
        /// The account's system-wide unique Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; protected set; }
        
        /// <summary>
        /// The account's login.
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; protected set; }
        
    }
}