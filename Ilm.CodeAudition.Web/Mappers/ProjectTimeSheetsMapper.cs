using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Ilm.CodeAudition.Service.Models;
using Ilm.CodeAudition.Web.Models;

namespace Ilm.CodeAudition.Web.Mappers
{
    public class ProjectTimeSheetsMapper
    {
        public TimeSheetsViewModel Map(IEnumerable<Timesheet> timeSheets)
        {
            var timeSheetsViewModel = new TimeSheetsViewModel();

            if (timeSheets.Any())
            {
                timeSheetsViewModel.ProjectTimeSheets = new List<ProjectTimeSheetViewModel>();

                foreach (var timeSheet in timeSheets)
                {
                    timeSheetsViewModel.ProjectTimeSheets.Add(new ProjectTimeSheetViewModel
                    {
                        Id = timeSheet.Id,
                        EmployeeId = timeSheet.EmployeeId,
                        ProjectName = timeSheet.ProjectName,
                        Monday = timeSheet.Monday, 
                        Tuesday = timeSheet.Tuesday,
                        Wednesday = timeSheet.Wednesday,
                        Thursday =  timeSheet.Thursday,
                        Friday = timeSheet.Friday
                    });
                }
            }

            return timeSheetsViewModel;
        }

        public IEnumerable<Timesheet> Map(TimeSheetsViewModel timeSheetsViewModel)
        {
            var timeSheets = new List<Timesheet>();
            if (timeSheetsViewModel != null && timeSheetsViewModel.ProjectTimeSheets != null &&
                timeSheetsViewModel.ProjectTimeSheets.Any())
            {
                foreach (var projectTimeSheetViewModel in timeSheetsViewModel.ProjectTimeSheets)
                {
                    timeSheets.Add(new Timesheet
                    {
                        Id = projectTimeSheetViewModel.Id,
                        EmployeeId = projectTimeSheetViewModel.Id,
                        ProjectName = projectTimeSheetViewModel.ProjectName,
                        Monday = projectTimeSheetViewModel.Monday,
                        Tuesday = projectTimeSheetViewModel.Tuesday,
                        Wednesday = projectTimeSheetViewModel.Wednesday,
                        Thursday = projectTimeSheetViewModel.Thursday,
                        Friday = projectTimeSheetViewModel.Friday
                    });
                }
            }


            return timeSheets.AsEnumerable();
        }
    }
}