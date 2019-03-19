using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Ilm.CodeAudition.Service.Models
{
    [DataContract]
    [Serializable]
    public class Timesheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string ProjectName { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Total { get; set; }
    }

}