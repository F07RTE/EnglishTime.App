using System.Collections.Generic;

namespace EnglishTime.ApiRest.Dtos
{
    public class ErrorDto
    {
        public List<string> Messages { get; set; }
        public bool Error { get; set; }
    }
}