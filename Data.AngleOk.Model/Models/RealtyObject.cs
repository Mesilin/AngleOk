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
		public Guid Id { get; set; }

		[Display(Name = "Кадастровый номер")]
		[Comment("Кадастровый номер")]
		[Required(ErrorMessage = "Не указан кадастровый номер")]
		[RegularExpression(@"\d{2}:\d{2}:\d{6,7}:\d*", ErrorMessage = "Некорректный кадастровый номер")]
		public string CadastralNumber { get; set; } = null!;

		[NotMapped]
        public Guid CityId { get; set; }

		[Comment("Почтовый индекс")]
		[Display(Name = "Почтовый индекс")]
		[RegularExpression(@"\d{0,6}", ErrorMessage = "Некорректный индекс")]
		public int? PostalCode { get; set; }

		public Guid? StreetId { get; set; }

		[ForeignKey("StreetId")]
		[Display(Name = "Улица")]
		[Comment("Улица")]
		public virtual Street? Street { get; set; }

		[Comment("Номер дома")]
		[Display(Name = "Номер дома")]
		[Range(1, Int32.MaxValue, ErrorMessage = "Некорректное значение")]
		public int? House { get; set; }

		[Comment("Литера дома")]
		[Display(Name = "Литера дома")]
		[RegularExpression(@"^[а-яА-Я'\s]{1}$",
			ErrorMessage = "Некорректные символы в поле Литера дома. Длина должна быть 1 символ")]
		[StringLength(1)]
		[Length(1, 1)]
		public string? HouseLetter { get; set; }

		[Comment("Корпус")]
		[Display(Name = "Корпус")]
		[Range(1, Int32.MaxValue, ErrorMessage = "Некорректное значение")]
		public int? Building { get; set; }

		[Comment("Квартира")]
		[Display(Name = "Квартира")]
		[Range(1, Int32.MaxValue, ErrorMessage = "Некорректное значение")]
		public int? Apartment { get; set; }


		[Display(Name = "Широта")]
		[Comment("Широта")]
		//[LatitudeValidation]
		[Range(typeof(decimal), "-90", "90", ErrorMessage = "Значение широты должно быть в диапазоне от -90° до +90°")]
		public decimal? Latitude { get; set; }

		[Display(Name = "Долгота")]
		[Comment("Долгота")]
		//[LongitudeValidation(true)]
		[Range(typeof(decimal), "-180", "180",
			ErrorMessage = "Значение долготы должно быть в диапазоне от -180\u00b0 до +180°")]
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


		[NotMapped] public string FullAddress => GetFullAddress(this);

		private string GetFullAddress(RealtyObject realtyObject)
		{
			var ret = "";
			if (realtyObject.PostalCode != null)
				ret += realtyObject.PostalCode+", ";
            if (realtyObject.Street != null)
                ret += realtyObject.Street.City.Region.Country.Name + ", " + realtyObject.Street.City.Region.Name +
                       ", г. " + realtyObject.Street.City.Name + ", ул. " + realtyObject.Street.Name;

			if (realtyObject.House != null)
				ret += ", д. " + realtyObject.House;
			if (realtyObject.HouseLetter != null)
				ret += ", лит. " + realtyObject.HouseLetter;
			if (realtyObject.Building != null)
				ret += ", корп. " + realtyObject.Building;
			if (realtyObject.Apartment != null)
			{
				ret += ", кв. " + realtyObject.Apartment;
			}

			return ret;
		}
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
