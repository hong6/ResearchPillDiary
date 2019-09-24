using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class Medication
    {
        public Medication()
        {
            PatientMedicationSchedule = new HashSet<PatientMedicationSchedule>();
        }

        public string MedicationId { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string Instructions { get; set; }
        public string Frequency { get; set; }

        public virtual ICollection<PatientMedicationSchedule> PatientMedicationSchedule { get; set; }
    }
}
