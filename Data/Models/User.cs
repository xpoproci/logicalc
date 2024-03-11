using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class User : BaseEntity
    {

        /// <summary>
        /// User's name
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Computed hash of user's password
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }
    }
}
