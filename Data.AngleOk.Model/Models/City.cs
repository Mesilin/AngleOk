using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
	[Comment("Города")]
	[Table("City")]
	public class City
	{
		[Comment("Идентификатор")]
		public Guid Id { get; set; }

		[Comment("Идентификатор субъекта")]
		public Guid RegionId { get; set; }

		[ForeignKey("RegionId")]
		[Comment("Субъект")]
		public virtual Region? Region { get; set; } = null!;

		[DisplayName("Наименование")]
		[Comment("Наименование")]
		public string Name { get; set; } = null!;

		[DisplayName("Население")]
		[Comment("Население")]
		public int Population { get; set; }

	}
}
