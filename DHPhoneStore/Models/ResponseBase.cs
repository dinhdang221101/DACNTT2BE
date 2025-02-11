using System;
using System.Text.Json.Serialization;

namespace DHPhoneStore.Models
{
	public class ResponseBase
	{
        public ResponseBase()
        {
            Status = "00";
        }

        [JsonPropertyName("status")] public string Status { get; set; } = string.Empty;

        [JsonPropertyName("message")] public string Message { get; set; } = string.Empty;

        [JsonPropertyName("data")] public object? Data { get; set; }
    }
}

