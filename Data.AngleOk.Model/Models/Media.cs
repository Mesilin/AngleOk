using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.AngleOk.Model.Models
{
    /// <summary>
    /// Фото и видео
    /// </summary>
    [Table("Media")]
    public class Media
    {
        /// <summary>
        /// Идентификатор медиаматериала
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Двоичные данные файла
        /// </summary>
        public byte[]? Data { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string? Path { get; set; }

        [Display(Name = "Имя файла")]
        public string FileName { get; set; } = null!;
        
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; } = null!;
        
        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid? RealtyObjectId { get; set; }
    }
}
