using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Фото
    /// </summary>
    [Table("Media")]
    [Comment("Фото")]
    public class Media
    {
		/// <summary>
		/// Идентификатор фото
		/// </summary>
		[Comment("Идентификатор фото")]
		public Guid Id { get; set; }
        
        /// <summary>
        /// Двоичные данные файла
        /// </summary>
		[Comment("Двоичные данные файла")]
        public byte[]? Data { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
		[Comment("Путь к файлу")]
        public string? Path { get; set; }

        [Display(Name = "Имя файла")]
		[Comment("Имя файла")]
        public string FileName { get; set; } = null!;
        
        /// <summary>
        /// Расширение файла
        /// </summary>
		[Comment("Расширение файла")]
        public string Extension { get; set; } = null!;

        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        [ForeignKey("RealtyObjectId")]
		[Comment("Идентификатор объекта недвижимости")]
        public Guid? RealtyObjectId { get; set; }

		[Comment("Признак титульного фото для объекта")]
        public bool IsTitle { get; set; }
	}
}
