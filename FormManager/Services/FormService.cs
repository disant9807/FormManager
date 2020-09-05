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

        public virtual Task<Form> GetFormById(int id)
        {
            var form = db.Forms.Where(y => y.ID == id).Include(y => y.inputFields).FirstOrDefault();

            return Task.FromResult(
                form is null || form.StatusDelete == 1 || form.PubDate > DateTime.Now
                ? null
                : form);
        }

        public virtual IAsyncEnumerable<Form> GetDataRecord()
        {
            return db.Forms
                .Include(u=>u.inputFields)
                .Where(p => p.PubDate <= DateTime.Now)
                .Where(o => o.StatusDelete != 1)
                .AsAsyncEnumerable();
        }

        public virtual IAsyncEnumerable<Form> GetDataRecord(int per_page, int current_page, string sort, string sort_dir, string search_params = null)
        {
            var forms = db.Forms
                .Include(u => u.inputFields)
                .Where(p => p.PubDate <= DateTime.Now)
                .Where(o => o.StatusDelete != 1);

            if (search_params != null)
            {
                forms = forms
                    .Where(z => z.inputFields.Any(v => v.Content.Contains(search_params)));
            }

            switch (sort)
            {
                case "id":
                    forms = sort_dir == "desc" ?
                        forms.OrderByDescending(s => s.ID) :
                        forms.OrderBy(s => s.ID);
                    break;
                case "pubDate":
                    forms = sort_dir == "desc" ?
                        forms.OrderByDescending(s => s.PubDate) :
                        forms.OrderBy(s => s.PubDate);
                    break;
                case "inputFields":
                    forms = sort_dir == "desc" ?
                        forms.OrderByDescending(s => s.inputFields.Count) :
                        forms.OrderBy(s => s.inputFields.Count);
                    break;
            }

            return forms
                .Skip((current_page - 1) * per_page)
                .Take(per_page)
                .AsAsyncEnumerable();
        }

        public async Task<bool> SaveForm(Form form)
        {
            try
            {
                db.Forms.Add(form);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteForm(int id)
        {
            try
            {
                Form form = db.Forms.Where(p => p.ID == id).Include(u => u.inputFields).FirstOrDefault();
                if (form != null)
                {
                    form.StatusDelete = 1;
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
