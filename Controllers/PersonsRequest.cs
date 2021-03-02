using Microsoft.AspNetCore.Mvc;

namespace helloazure.Controllers {
    public class PersonsRequest {
        [FromQuery(Name = "limit")]
        public int Limit { get; set; } = 15;

        [FromQuery(Name = "offset")]
        public int Offset { get; set; }
    }
}