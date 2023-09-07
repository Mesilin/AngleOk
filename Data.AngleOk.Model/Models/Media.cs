using System;
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
        public Guid MediaId { get; set; }
        
        /// <summary>
        /// Двоичные данные файла
        /// </summary>
        public byte[]? Data { get; set; }
        
        /// <summary>
        /// Путь к файлу на диске
        /// </summary>
        public string? Path { get; set; }
        
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; } = null!;
        
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; } = null!;
        
        /// <summary>
        /// Идентификатор объекта недвижимости
        /// </summary>
        public Guid RealtyObjectId { get; set; }

        [ForeignKey("RealtyObjectId")]
        public RealtyObject RealtyObject { get; set; } = null!;
    }
}
