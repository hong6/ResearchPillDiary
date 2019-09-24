using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class TrialMedication
    {
        public string TrialMedicationId { get; set; }
        public string TrialId { get; set; }
        public string MedicationId { get; set; }
        public string Optional { get; set; }

        public virtual Trial Trial { get; set; }
    }
}
