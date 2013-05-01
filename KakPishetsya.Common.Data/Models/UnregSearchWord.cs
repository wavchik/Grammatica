using System.ComponentModel.DataAnnotations;

namespace KakPishetsya.Common.Data.Models
{
    public class UnregSearchWord : BaseModel
    {
        [Display(Name = "Название")]
        [Required]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        public string Name { get; set; }

        [Display(Name = "Количество поисков")]
        [Required]
        public int SearchCount { get; set; }
    }
}