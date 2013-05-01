using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KakPishetsya.Common.Data.Models
{
    public class Rule : BaseModel
    {
        [Display(Name = "Название")]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Определение")]
        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Description { get; set; }
    }
}