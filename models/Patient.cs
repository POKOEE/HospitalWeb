using System.ComponentModel.DataAnnotations;

namespace HospitalWeb.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО пациента")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Диагноз")]
        public string? Diagnosis { get; set; }

        [Phone]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        public List<Appointment> Appointments { get; set; } = new();
    }
}