using FormManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Services
{
    public interface IFormService
    {
        IAsyncEnumerable<Form> GetDataRecord();

        Task SaveForm(Form form);
    }
}
