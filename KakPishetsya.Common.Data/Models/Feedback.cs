using System.ComponentModel.DataAnnotations;

namespace KakPishetsya.Common.Data.Models
{
    public class Feedback : BaseModel
    {
        [Display(Name = "Имя")]
        [Required]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        public string Name { get; set; }

        [Display(Name = "Электронная почта")]
        [Required]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        public string Email { get; set; }

        [Display(Name = "Текст")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}