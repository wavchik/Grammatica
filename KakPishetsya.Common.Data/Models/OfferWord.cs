using System.ComponentModel.DataAnnotations;

namespace KakPishetsya.Common.Data.Models
{
    public class OfferWord : BaseModel
    {
        [Display(Name = "Название")]
        [Required]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        public string Name { get; set; }
    }
}