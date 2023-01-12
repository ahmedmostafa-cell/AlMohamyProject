using AlMohamyProject.Models;
using BL;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace AlMohamyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApprovedOfficeController : Controller
    {
        ApprovedOfficeService approvedOfficeService;
        MainConsultingService mainConsultingService;
        AlMohamyDbContext ctx;
        public ApprovedOfficeController(ApprovedOfficeService ApprovedOfficeService,MainConsultingService MainConsultingService, AlMohamyDbContext context)
        {
            mainConsultingService = MainConsultingService;
            approvedOfficeService = ApprovedOfficeService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,المكاتب المعتمدة")]
        public IActionResult Index(string Id)
        {

            HomePageModel model = new HomePageModel();
            model.lstApprovedOffices = approvedOfficeService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbApprovedOffice ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.ApprovedOfficeId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.ApprovedOfficeLogo = ImageName;
                        }
                    }





                    var result = approvedOfficeService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Approved Office Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Approved Office Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            string ImageName = Guid.NewGuid().ToString() + ".jpg";
                            var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                            using (var stream = System.IO.File.Create(filePaths))
                            {
                                await file.CopyToAsync(stream);
                            }
                            ITEM.ApprovedOfficeLogo = ImageName;
                        }
                    }






                    var result = approvedOfficeService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Approved Office Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Approved Office Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstApprovedOffices = approvedOfficeService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف المكاتب المعتمدة")]
        public IActionResult Delete(Guid id)
        {

            TbApprovedOffice oldItem = ctx.TbApprovedOffices.Where(a => a.ApprovedOfficeId == id).FirstOrDefault();



            var result = approvedOfficeService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Approved Office Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Approved Office Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstApprovedOffices = approvedOfficeService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل المكاتب المعتمدة")]
        public IActionResult Form(Guid? id)
        {
            TbApprovedOffice oldItem = ctx.TbApprovedOffices.Where(a => a.ApprovedOfficeId == id).FirstOrDefault();
            oldItem = ctx.TbApprovedOffices.Where(a => a.ApprovedOfficeId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
