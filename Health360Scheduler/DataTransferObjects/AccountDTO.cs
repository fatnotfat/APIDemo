using Health360Scheduler.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Health360Scheduler.DataTransferObjects
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountRole Role { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountStatus Status { get; set; }
    }
}
