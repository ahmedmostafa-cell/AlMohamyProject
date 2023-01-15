using BL;
using Microsoft.AspNetCore.Mvc;

namespace AlMohamyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        NotificationService notificationService;
        AlMohamyDbContext ctx;
        public NotificationController(NotificationService NotificationService,MainConsultingService MainConsultingService, AlMohamyDbContext context)
        {
            notificationService = NotificationService;
            ctx = context;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
