using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.AngleOk.Model.Models
{
	/// <summary>
	/// ������
	/// </summary>
	[Table("Country")]
	[Comment("������")]
	public class Country
	{
		[Comment("�������������")]
		public Guid Id { get; set; }

		[DisplayName("������������")]
		[Comment("������������")]
		public string Name { get; set; } = null!;

		[DisplayName("������ ������������")]
		[Comment("������ ������������")]
		public string? FullName { get; set; }

		[DisplayName("������������ �� ���������� �����")]
		[Comment("������������ �� ���������� �����")]
		public string EnglishName { get; set; }=null!;

		[DisplayName("Alpha-2 ��� �� ISO 3166-1")]
		[Comment("Alpha-2 ��� �� ISO 3166-1")]
		[MaxLength(2)]
		[StringLength(2)]
		public string Alpha2 { get; set; } = null!;

		[DisplayName("Alpha-3 ��� �� ISO 3166-1")]
		[Comment("Alpha-3 ��� �� ISO 3166-1")]
		[MaxLength(3)]
		[StringLength(3)]
		public string Alpha3 { get; set; } = null!;

		[DisplayName("��� �� ISO 3166-1")]
		[Comment("Iso ��� �� ISO 3166-1")]
		public int Iso{ get; set; }
	}
}