using System.ComponentModel.DataAnnotations;

namespace KakPishetsya.Common.Data.Models
{
    public class User : BaseModel
    {
        [Display(Name = "Логин")]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}