using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class PatientAppointment
    {
        public string PatientAppointmentId { get; set; }
        public string PatientId { get; set; }
        public string TrialId { get; set; }
        public string DoctorId { get; set; }
        public string LocationId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Trial Trial { get; set; }
    }
}
