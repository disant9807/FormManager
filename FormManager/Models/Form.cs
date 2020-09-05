using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FormManager.Models
{
    using System.Globalization;
    public class Form
    {
        public int ID { get; set; }

        public int StatusDelete { get; set; } = 0;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime LastModified { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime PubDate { get; set; } = DateTime.Now;

        public IList<InputField> inputFields { get; set; } = new List<InputField>();

    }
}
