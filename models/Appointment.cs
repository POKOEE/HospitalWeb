using System.ComponentModel.DataAnnotations;

namespace HospitalWeb.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Пациент")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [Display(Name = "Врач")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Дата приёма")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name = "Примечание")]
        public string? Notes { get; set; }
    }
}