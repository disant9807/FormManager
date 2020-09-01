using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Models
{
    using System.Globalization;
    public class Form
    {
        public string ID { get; set; } = DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture);
        
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        public DateTime PubDate { get; set; } = DateTime.UtcNow;

        public IList<InputField> inputFields { get; set; } = new List<InputField>();

    }
}
