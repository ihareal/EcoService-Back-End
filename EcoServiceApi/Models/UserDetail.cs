using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoServiceApi.Models
{
    public class UserDetail
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 0 - user
        /// 1 - admin rights
        /// </summary>        
        [Required]
        public int isAdmin { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string DwellingType { get; set; }

        /// <summary>
        /// flat
        /// house
        /// </summary>
        public int StageNumber { get; set; }

        public int StageAmount { get; set; }

        #endregion

        #region FK

        public List<UserEventDetail> UserEventDetail { get; set; }
        public List<PollutionDetail> PollutionDetails { get; set; }
        public List<UserNewsDetail> UserNewsDetails { get; set; }

        #endregion

    }
}

