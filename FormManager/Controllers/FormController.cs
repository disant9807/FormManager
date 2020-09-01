using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormManager.Models;
using FormManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormManager.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService formService;
        public FormController(IFormService formService)
        {
            this.formService = formService;
        }

        public async Task AddForm()
        {
            IList<InputField> fields = new List<InputField>();
            Request.Form.ToList().ForEach(p => fields.Add(new InputField(p.Value, p.Key)));

            Form form = new Form();
            form.inputFields = fields;

            await formService.SaveForm(form);
        }
        // GET: FormController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FormController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FormController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
