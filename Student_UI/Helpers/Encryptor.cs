using JWT;
using JWT.Builder;
using Newtonsoft.Json;
using Student_UI.Models;
using System.Collections.Generic;

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
