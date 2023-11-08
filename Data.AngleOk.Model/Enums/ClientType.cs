using System.ComponentModel.DataAnnotations;

namespace Data.AngleOk.Model.Enums
{
    /// <summary>
    /// Типы клиентов
    /// </summary>
    public enum ClientType
    {
        [Display(Name = "Физическое лицо")]
        Person=0,
        [Display(Name = "Юридическое лицо")]
        Company= 1
    }
}
