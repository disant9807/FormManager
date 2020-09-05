using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Utils
{
    public class ErrorResult
    {
        public bool error { get; set; }

        public ErrorResult(bool error)
        {
            this.error = error;
        }
    }
}
