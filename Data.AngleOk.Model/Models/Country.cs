using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
	/// <summary>
	/// Страны
	/// </summary>
	[Table("Country")]
	[Comment("Страны")]
	public class Country
	{
		[Comment("Идентификатор")]
		public Guid Id { get; set; }

		[DisplayName("Наименование")]
		[Comment("Наименование")]
		public string Name { get; set; } = null!;

		[DisplayName("Полное наименование")]
		[Comment("Полное наименование")]
		public string? FullName { get; set; }

		[DisplayName("Наименование на английском языке")]
		[Comment("Наименование на английском языке")]
		public string EnglishName { get; set; }=null!;

		[DisplayName("Alpha-2 код по ISO 3166-1")]
		[Comment("Alpha-2 код по ISO 3166-1")]
		[MaxLength(2)]
		[StringLength(2)]
		public string Alpha2 { get; set; } = null!;

		[DisplayName("Alpha-3 код по ISO 3166-1")]
		[Comment("Alpha-3 код по ISO 3166-1")]
		[MaxLength(3)]
		[StringLength(3)]
		public string Alpha3 { get; set; } = null!;

		[DisplayName("Код по ISO 3166-1")]
		[Comment("Iso код по ISO 3166-1")]
		public int Iso{ get; set; }
	}
}