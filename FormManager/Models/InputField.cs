using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Models
{
    public class InputField
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Content { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public DateTime PubDate { get; set; } = DateTime.UtcNow;

        public InputField(string content, string name)
        {
            Content = content;
            Name = name;
        }
    }
}
