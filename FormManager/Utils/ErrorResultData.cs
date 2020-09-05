using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Utils
{
    public class ErrorResultData<T>
    {
        public T data { get; set; } = default(T);

        public bool error { get; set; }

        public ErrorResultData (bool error, T data)
        {
            this.error = error;
            this.data = data;
        }
    }
}
