using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KakPishetsya.Common.Data.Models
{
    public class Word : BaseModel
    {
        [Display(Name = "Название")]
        [Required]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        [Remote("IsWordExists", "Words", HttpMethod = "POST", ErrorMessage = "Данное слово уже есть в базе!")]
        public string Name { get; set; }

        [Display(Name = "Короткая ссылка")]
        [Required]
        [MaxLength(64, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(64)]
        [Remote("IsSmartWordExists", "Words", HttpMethod = "POST", ErrorMessage = "Такая короткая сслыка на слово уже зарегестрирована в базе!")]
        public string SmartName { get; set; }

        [Display(Name = "HTML-тег H1")]
        [MaxLength(128, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(128)]
        public string H1 { get; set; }

        [Display(Name = "HTML-тег Title")]
        [MaxLength(128, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(128)]
        public string Title { get; set; }

        [Display(Name = "Мета-тег Keywords")]
        [MaxLength(128, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(128)]
        public string Keywords { get; set; }

        [Display(Name = "Мета-тег \"Описание\"")]
        [MaxLength(128, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(128)]
        public string Description { get; set; }

        [Display(Name = "Примеры неправильного написания (вводите слова через запятую)")]
        [MaxLength(128, ErrorMessage = "Максимальный размер поля не должен превышать 64 символа")]
        [StringLength(128)]
        public string InvalidDescription { get; set; }

        [Display(Name = "Пояснения правописания")]
        [Required]
        [DataType(DataType.MultilineText)]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Explanation { get; set; }

        //[Display(Name = "Пример правописания")]
        //[DataType(DataType.MultilineText)]
        //[UIHint("tinymce_jquery_full"), AllowHtml]
        //public string SpellingExample { get; set; }

        [Display(Name = "RuleId")]
        public int? RuleId { get; set; }

        [Display(Name = "Правило")]
        public virtual Rule Rule { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateModified { get; set; }
    }
}