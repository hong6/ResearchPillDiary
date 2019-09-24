using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class DiarySymptom
    {
        public string DiarySymptomId { get; set; }
        public string PatientId { get; set; }
        public string Note { get; set; }
        public string Attachment { get; set; }
        public string Pain { get; set; }
        public DateTime? DiaryEntryDateTime { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
