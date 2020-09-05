using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormManager.Models;
using FormManager.Services;
using FormManager.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : Controller
    {
        private readonly IFormService formService;
        public FormController(IFormService formService)
        {
            this.formService = formService;
        }

        [Route("/api")]
        [HttpPost]
        public async Task<JsonResult> AddForm()
        {
            IList<InputField> fields = new List<InputField>();
            Request.Form.ToList().ForEach(p => fields.Add(new InputField(p.Value, p.Key)));

            Form form = new Form();
            form.inputFields = fields;

            bool result = await formService.SaveForm(form);
            return await Task.FromResult(result == false
                ? Json(new ErrorResult(true))
                : Json(new ErrorResultData<Form>(false, form)));
        }

        [Route("/api")]
        [HttpGet]
        public async Task<ActionResult<DtableResult<List<Form>>>> GerForm(int per_page, int current_page, string sort, string sort_dir, string search_params = null)
        {
            // return await formService.GetDataRecord();
            IAsyncEnumerable<Form> myData = formService.GetDataRecord(per_page, current_page, sort, sort_dir, search_params);
            
            List<Form> data = new List<Form>();
            await foreach (Form i in myData)
                data.Add(i);

            return await Task.FromResult(new DtableResult<List<Form>>(per_page, current_page, sort, sort_dir, data));
        }

        [Route("/api/{id?}")]
        [HttpGet]
        public async Task<Form> GetFormByID(int id)
        {
            var form = await formService.GetFormById(id);
            return await Task.FromResult(form);
        }

        [Route("/api/{id?}/delete")]
        [HttpPost]
        public async Task<JsonResult> DeleteFormByID(int id)
        {
            var result = await formService.DeleteForm(id);
            return await Task.FromResult(result == false
                ? Json(new ErrorResult(true))
                : Json(new ErrorResult(false)));
        }
    }
}
