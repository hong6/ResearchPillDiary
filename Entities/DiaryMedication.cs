using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class DiaryMedication
    {
        public string DiaryMedicationId { get; set; }
        public string PatientId { get; set; }
        public DateTime? DiaryEntryDateTime { get; set; }
        public bool? DidTake { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
