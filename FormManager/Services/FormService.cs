using FormManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormManager.Services
{
    public class FormService: IFormService
    {
        private Context db;
        public FormService(Context context)
        {
            db = context;
        }
        public virtual IAsyncEnumerable<Form> GetDataRecord()
        {
            return db.Forms
                .Where(p => p.PubDate <= DateTime.UtcNow).AsAsyncEnumerable();
        }

        public async Task SaveForm(Form form)
        {
            db.Forms.Add(form);
            await db.SaveChangesAsync();
        }
    }
}
