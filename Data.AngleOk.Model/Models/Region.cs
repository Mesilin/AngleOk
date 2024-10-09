using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
	[Table("Region")]
	[Comment("Субъекты")]
	public class Region
	{
		public Guid Id { get; set; }

		[Comment("Идентификатор страны")]
		public Guid CountryId { get; set; }

		[ForeignKey("CountryId")]
		public virtual Country? Country { get; set; }

		[DisplayName("Наименование")]
		[Comment("Наименование")]
		public string Name { get; set; } = null!;

		[DisplayName("Наименование на английском языке")]
		[Comment("Наименование на английском языке")]
		public string EnglishName { get; set; } = null!;
	}
}
