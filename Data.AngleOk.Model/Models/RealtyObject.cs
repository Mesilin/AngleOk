using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Объекты недвижимости
    /// </summary>
    [Table("RealtyObject")]
    [Comment("Объекты недвижимости")]
    public class RealtyObject
    {
		/// <summary>
		/// Идентификатор
		/// </summary>
		[Comment("Идентификатор")] 
		public Guid Id {get; set;}

        [Display(Name = "Кадастровый номер")]
		[Comment("Кадастровый номер")]
        [Required(ErrorMessage = "Не указан кадастровый номер")]
        [RegularExpression(@"\d{2}:\d{2}:\d{6,7}:\d*", ErrorMessage = "Некорректный кадастровый номер")]
        public string CadastralNumber { get; set;} = null!;

        [Display(Name = "Адрес")]
		[Comment("Адрес")]
        [Required(ErrorMessage = "Не указан адрес")]
        public string Address { get; set; } = null!;

        [Display(Name = "Широта")]
		[Comment("Широта")]
        //[LatitudeValidation]
        [Range(typeof(decimal),"-90", "90", ErrorMessage = "Значение широты должно быть в диапазоне от -90° до +90°")]
		public decimal? Latitude { get; set; }

        [Display(Name = "Долгота")]
		[Comment("Долгота")] 
        //[LongitudeValidation(true)]
        [Range(typeof(decimal),"-180", "180", ErrorMessage = "Значение долготы должно быть в диапазоне от -180\u00b0 до +180°")]
		public decimal? Longitude { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
		[Comment("Описание")] 
        public string? Description { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public Guid RealtyObjectKindId { get; set; }
        [ForeignKey("RealtyObjectKindId")]
		[Comment("тип")] 
        public virtual RealtyObjectKind? RealtyObjectKind { get; set; } = null!;

        /// <summary>
        /// Список фотографий и пр медиаматериалов
        /// </summary>
        public virtual List<Media>? MediaMaterials { get; set; }
    }

    public class LatitudeValidationAttribute : ValidationAttribute
    {
	    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	    {
		    if (!decimal.TryParse((string)value, out _))
			    return new ValidationResult("Введите корректное значение широты");

            if (value is null || value == "")
                return new ValidationResult("Широта не может быть пустой");

            var latitude = Convert.ToDecimal(value);
		    if (latitude < -90m || latitude > 90m)
			    return new ValidationResult("Значение широты должно быть в диапазоне от -90° до +90°");

		    return ValidationResult.Success;
	    }
    }
    public class LongitudeValidationAttribute : ValidationAttribute
    {
	    private readonly bool _mayBeEmpty;

		public LongitudeValidationAttribute(bool mayBeEmpty)
		{
			_mayBeEmpty = mayBeEmpty;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	    {
		    if (!decimal.TryParse((string)value, out _))
			    return new ValidationResult("Введите корректное значение долготы");

		    if (!_mayBeEmpty && (value is null || value == ""))
				return new ValidationResult("долгота не может быть пустой");

		    var latitude = Convert.ToDecimal(value);
		    if (latitude < -90m || latitude > 90m)
			    return new ValidationResult("Значение широты должно быть в диапазоне от -90° до +90°");

		    return ValidationResult.Success;
	    }
    }
}
