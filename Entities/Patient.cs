using System;
using System.Collections.Generic;

namespace ResearchPillDiary.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            DiaryMedication = new HashSet<DiaryMedication>();
            DiarySymptom = new HashSet<DiarySymptom>();
            DiaryVital = new HashSet<DiaryVital>();
            PatientAppointment = new HashSet<PatientAppointment>();
            PatientMedicationSchedule = new HashSet<PatientMedicationSchedule>();
        }

        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyContactPhone { get; set; }

        public virtual ICollection<DiaryMedication> DiaryMedication { get; set; }
        public virtual ICollection<DiarySymptom> DiarySymptom { get; set; }
        public virtual ICollection<DiaryVital> DiaryVital { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointment { get; set; }
        public virtual ICollection<PatientMedicationSchedule> PatientMedicationSchedule { get; set; }
    }
}
