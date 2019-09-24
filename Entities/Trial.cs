using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class Trial
    {
        public Trial()
        {
            PatientAppointment = new HashSet<PatientAppointment>();
            TrialMedication = new HashSet<TrialMedication>();
        }

        public string TrialId { get; set; }
        public string TrialName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<PatientAppointment> PatientAppointment { get; set; }
        public virtual ICollection<TrialMedication> TrialMedication { get; set; }
    }
}
