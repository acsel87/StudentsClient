using Newtonsoft.Json;
using Student_UI.Models;

namespace Student_UI.Helpers
{
    public class Encryptor
    {
        public ResponseModel<T> ResponseDeserializer<T>(string serializedResponse)
        {
            return JsonConvert.DeserializeObject<ResponseModel<T>>(serializedResponse);
        }
    }
}
