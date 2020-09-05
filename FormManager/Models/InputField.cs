using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FormManager.Models
{
    public class InputField
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Content { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-yyyy-MM}")]
        public DateTime PubDate { get; set; } = DateTime.Now;

        public InputField(string content, string name)
        {
            Content = content;
            Name = name;
        }
    }
}
