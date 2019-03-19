using System.Data.Entity;
using Ilm.CodeAudition.Service.Models;

namespace Ilm.CodeAudition.Service
{
    public class Database : DbContext
    {
        public DbSet<Timesheet> Timesheets { get; set; }
    }
}