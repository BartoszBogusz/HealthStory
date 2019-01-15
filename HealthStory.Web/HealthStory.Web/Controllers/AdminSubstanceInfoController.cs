﻿using HealthStory.Web.Application.AdminSubstance;
using HealthStory.Web.Application.Units.SelectList;
using HealthStory.Web.Models.SubstanceDefinition;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class AdminSubstanceInfoController : Controller
    {
        private readonly IUnitSelectListProvider _unitSelectListProvider;
        private readonly IAdminSubstanceInfoService _adminSubstanceInfoService;

        public AdminSubstanceInfoController(IUnitSelectListProvider unitSelectListProvider,
            IAdminSubstanceInfoService adminSubstanceInfoService)
        {
            _unitSelectListProvider = unitSelectListProvider;
            _adminSubstanceInfoService = adminSubstanceInfoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var unitList = _unitSelectListProvider.Get();
            var model = new SubstanceDefinitionCreateModel
            {
                UnitSelectList = unitList
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SubstanceDefinitionCreateModel model)
        {
            _adminSubstanceInfoService.Create(model);
            return View("Index");
        }
    }
}
