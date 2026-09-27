using System.ComponentModel.DataAnnotations;

namespace HospitalWeb.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО врача")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите специализацию")]
        [Display(Name = "Специализация")]
        public string Specialization { get; set; } = string.Empty;

        [Display(Name = "Кабинет")]
        public string? Office { get; set; }

        [Phone]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        public List<Appointment> Appointments { get; set; } = new();
    }
}