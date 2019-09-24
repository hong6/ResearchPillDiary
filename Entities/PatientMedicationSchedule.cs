using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class PatientMedicationSchedule
    {
        public string PatientMedicationScheduleId { get; set; }
        public string PatientId { get; set; }
        public string MedicationId { get; set; }
        public string TrialId { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? Day { get; set; }
        public string Dosage { get; set; }
        public string Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Active { get; set; }
        public string PrescribingDoctor { get; set; }
        public string Pharmacy { get; set; }
        public string Reminder { get; set; }

        public virtual Medication Medication { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
