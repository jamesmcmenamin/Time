using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Xml.Schema;
using Ilm.CodeAudition.Service.Models;


namespace Ilm.CodeAudition.Service
{
    [ServiceContract]
    public class TimeTrackerService
    {
        public void Save(Timesheet timeSheet)
        {
            var db = new Database();
            var dbTimesheet = db.Timesheets.Find(timeSheet.Id);
            dbTimesheet.ProjectName = timeSheet.ProjectName;
            dbTimesheet.Monday = timeSheet.Monday;
            dbTimesheet.Tuesday = timeSheet.Tuesday;
            dbTimesheet.Wednesday = timeSheet.Wednesday;
            dbTimesheet.Thursday = timeSheet.Thursday;
            dbTimesheet.Friday = timeSheet.Friday;
            dbTimesheet.Total = (timeSheet.Monday + timeSheet.Tuesday + timeSheet.Wednesday + timeSheet.Thursday + timeSheet.Friday);
            db.SaveChanges();
        }

        public void Add()
        {
            var db = new Database();
            db.Timesheets.Add(new Timesheet
            {
                ProjectName = "",
                Monday = 0,
                Tuesday = 0,
                Wednesday = 0,
                Thursday = 0,
                Friday = 0,
                Total = 0
            });
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new Database();
            var timesheet = db.Timesheets.Single(x => x.Id == id);
            db.Timesheets.Remove(timesheet);
            db.SaveChanges();
        }

        





        public IList<Timesheet> GetAll()
        {
            var db = new Database();
            return db.Timesheets.ToList();
        }
    }
}
