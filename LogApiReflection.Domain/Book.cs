using System.Text.Json.Serialization;

namespace LogApiReflection.Domain
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public double Value { get; set; }
        public int NumberOfPages { get; set; }
        public Author Author { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Category Category { get; set; }
    }
}