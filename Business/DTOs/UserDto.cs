using Business.Helpers;
using Newtonsoft.Json;

namespace Business.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string ToEncryptedString()
        {
            var str = JsonConvert.SerializeObject(this);
            return EncryptHelper.Encrypt(str);
        }

        public UserDto FromEncryptedString(string input)
        {
            var str = EncryptHelper.Decrypt(input);
            return JsonConvert.DeserializeObject<UserDto>(str);
        }
    }
}
