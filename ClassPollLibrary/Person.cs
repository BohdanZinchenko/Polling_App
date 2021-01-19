using System.Text.Json.Serialization;

namespace ClassPollLibrary
{
    public class PersonAccount
    {
        [JsonPropertyName("FirstName")]
        public string FirstName { get;  set; }
        [JsonPropertyName("LastName")]
        public string LastName { get;  set; }
        [JsonPropertyName("Age")]
        public int Age { get;  set; }
        [JsonPropertyName("IsGenderMan")]
        public bool IsGenderMan { get;  set; }
        [JsonPropertyName("Phone")]
        public int Phone { get;  set; }
        [JsonPropertyName("Password")]
        public string Password { get;  set; }
    }
}