using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
	[Table("Street")]
	[Comment("Улицы")]
	public class Street
	{
		[Comment("Идентификатор")]
		public Guid Id { get; set; }

		[DisplayName("Наименование")]
		[Comment("Наименование")]
		public string Name { get; set; }

		[Comment("Идентификатор города")]
		public Guid CityId { get; set; }

		
		[ForeignKey("CityId")]
		[Comment("Город")]
		public virtual City? City { get; set; } = null!;
	}
}
