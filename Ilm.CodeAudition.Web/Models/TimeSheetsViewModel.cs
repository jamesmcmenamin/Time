using System.Collections.Generic;
using System.Linq;

namespace Ilm.CodeAudition.Web.Models
{
    public class TimeSheetsViewModel
    {
        public  List<ProjectTimeSheetViewModel> ProjectTimeSheets { get; set; }
        public int Total => ProjectTimeSheets.Any() ? ProjectTimeSheets.Sum(x => x.Total) : 0;
    }
}