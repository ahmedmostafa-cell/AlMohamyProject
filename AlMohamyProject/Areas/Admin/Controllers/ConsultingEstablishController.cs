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
    public class ConsultingEstablishController : Controller
    {
        ConsultingEstablishService consultingEstablishService;
        MainConsultingService mainConsultingService;
        AlMohamyDbContext ctx;
        public ConsultingEstablishController(ConsultingEstablishService ConsultingEstablishService,MainConsultingService MainConsultingService, AlMohamyDbContext context)
        {
            mainConsultingService = MainConsultingService;
            consultingEstablishService = ConsultingEstablishService;
            ctx = context;

        }
        [Authorize(Roles = "Admin,انشاء الاستشارة")]
        public IActionResult Index(string Id)
        {

            HomePageModel model = new HomePageModel();
            model.lstConsultingEstablishs = consultingEstablishService.getAll();

            return View(model);


        }




        [HttpPost]
        public async Task<IActionResult> Save(TbConsultingEstablish ITEM, int id, List<IFormFile> files)
        {
            if (ITEM.ConsultingId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {


                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.MainConsultingImage = ImageName;
                    //    }
                    //}





                    var result = consultingEstablishService.Add(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Consulting Establish Profile successfully Created.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Consulting Establish Profile  Creating.";
                    }


                }


            }
            else
            {
                if (ModelState.IsValid)
                {
                    //foreach (var file in files)
                    //{
                    //    if (file.Length > 0)
                    //    {
                    //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    //        using (var stream = System.IO.File.Create(filePaths))
                    //        {
                    //            await file.CopyToAsync(stream);
                    //        }
                    //        ITEM.MainConsultingImage = ImageName;
                    //    }
                    //}






                    var result = consultingEstablishService.Edit(ITEM);
                    if (result == true)
                    {
                        TempData[SD.Success] = "Consulting Establish Profile successfully Updated.";
                    }
                    else
                    {
                        TempData[SD.Error] = "Error in Consulting Establish Profile  Updating.";
                    }

                }
            }




            HomePageModel model = new HomePageModel();
            model.lstConsultingEstablishs = consultingEstablishService.getAll();
            return View("Index", model);
        }




        [Authorize(Roles = "Admin,حذف انشاء الاستشارة")]
        public IActionResult Delete(Guid id)
        {

            TbConsultingEstablish oldItem = ctx.TbConsultingEstablishes.Where(a => a.ConsultingId == id).FirstOrDefault();



            var result = consultingEstablishService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "Consulting Establish Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in Consulting Establish Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstConsultingEstablishs = consultingEstablishService.getAll();
            return View("Index", model);



        }



        [Authorize(Roles = "Admin,اضافة او تعديل انشاء الاستشارة")]
        public IActionResult Form(Guid? id)
        {
            TbConsultingEstablish oldItem = ctx.TbConsultingEstablishes.Where(a => a.ConsultingId == id).FirstOrDefault();
            oldItem = ctx.TbConsultingEstablishes.Where(a => a.ConsultingId == id).FirstOrDefault();

            return View(oldItem);
        }
    }
}
