using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Utils
{
    public class DtableResult<T>
    {
        public int per_page { get; set; }
        public int current_page { get; set; }
        public string sort { get; set; }
        public string sort_dir { get; set; }
        public T data { get; set; }

        public DtableResult(int perPage, int currentPage, string sort, string sortDir, T data)
        {
            this.per_page = perPage;
            this.current_page = currentPage;
            this.sort = sort;
            this.sort_dir = sortDir;
            this.data = data;
        }

    }
}
