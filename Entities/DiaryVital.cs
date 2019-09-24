using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class DiaryVital
    {
        public string DiaryVitalId { get; set; }
        public string PatientId { get; set; }
        public string BodyTemp { get; set; }
        public string BloodPressure { get; set; }
        public string BodyWeight { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
