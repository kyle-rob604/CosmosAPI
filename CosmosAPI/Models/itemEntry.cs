using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosAPI.Models
{
    public partial class itemEntry
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("request_attachments", NullValueHandling = NullValueHandling.Ignore)]
        public RequestAttachments RequestAttachments { get; set; }

        [JsonProperty("request_properties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> RequestProperties { get; set; }

        [JsonProperty("request_status", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestStatus { get; set; }

        [JsonProperty("request_type", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestType { get; set; }

        [JsonProperty("scheduled_date_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ScheduledDateTime { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("submit_date_time", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? SubmitDateTime { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public partial class RequestAttachments
    {
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Input { get; set; }

        [JsonProperty("output", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Output { get; set; }
    }
}