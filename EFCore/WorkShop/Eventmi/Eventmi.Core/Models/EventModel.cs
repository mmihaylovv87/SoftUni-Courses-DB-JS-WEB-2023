namespace Eventmi.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Събитие
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Идентификатор на запис
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Име на събитието
        /// </summary>
        [Display(Name = "Име на съобщението")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е дълго между {2} и {1} символа")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Начална дата и час
        /// </summary>
        [Display(Name = "Начална дата и час")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Крайна дата и час
        /// </summary>
        [Display(Name = "Крайна дата и час")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime End { get; set; }

        /// <summary>
        /// Място на провеждане
        /// </summary>
        [Display(Name = "Място на провеждане")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Полето '{0}' трябва да е дълго между {2} и {1} символа")]
        public string Place { get; set; } = null!;
    }
}