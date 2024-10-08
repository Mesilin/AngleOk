﻿using AngleOk.Web.Repositories.Abstract;
using AngleOk.Web.Services;
using Data.AngleOk.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngleOk.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("{area}/TextFields")]
    public class TextFieldsController(DataManager dataManager) : Controller
    {
        [HttpGet]
        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                
                dataManager.TextFields.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
