using System.Collections.Generic;
using System.Web.Mvc;
using Ilm.CodeAudition.Service;
using Ilm.CodeAudition.Service.Models;
using Ilm.CodeAudition.Web.Mappers;
using Ilm.CodeAudition.Web.Models;

namespace Ilm.CodeAudition.Web.Controllers
{ 
    public class TimesheetController : Controller
    {
        public ViewResult Index()
        {
            var mapper = new ProjectTimeSheetsMapper();
            var service = new TimeTrackerService();
            var timeSheets = service.GetAll();
            var timeSheetsViewModel = mapper.Map(timeSheets);

            return View(timeSheetsViewModel);
        }

        [HttpPost]
        public RedirectToRouteResult Save(TimeSheetsViewModel timeSheetsViewModel)
        {
            var mapper = new ProjectTimeSheetsMapper();
            var service = new TimeTrackerService();
            var timeSheets = mapper.Map(timeSheetsViewModel);

            foreach (var timeSheet in timeSheets)
            {
                service.Save(timeSheet);
            }

            return RedirectToAction("Index");

        }

        public RedirectToRouteResult Add()
        {
            var service = new TimeTrackerService();
            service.Add();

            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Delete(int id)
        {
            var service = new TimeTrackerService();
            service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}