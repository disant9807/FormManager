using FormManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Services
{
    public interface IFormService
    {
        Task<Form> GetFormById(int id);

        IAsyncEnumerable<Form> GetDataRecord();

        IAsyncEnumerable<Form> GetDataRecord(int per_page, int current_page, string sort, string sort_dir, string search_params = null);

        Task<bool> SaveForm(Form form);

        Task<bool> DeleteForm(int id);
    }
}
