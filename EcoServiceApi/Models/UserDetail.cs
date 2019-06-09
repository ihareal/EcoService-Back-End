using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoServiceApi.Models
{
    public class UserDetail
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Email { get; set; }

        /// <summary>
        /// 0 - user
        /// 1 - admin rights
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(4)")]
        public int isAdmin { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string DwellingType { get; set; }

        /// <summary>
        /// flat
        /// house
        /// </summary>

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public int StageNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(5)")]
        public int StageAmount { get; set; }

        #endregion

        #region FK

        public List<EventDetail> EventDetails { get; set; }
        public List<PollutionDetail> PollutionDetails { get; set; }
        public List<NewsDetail> NewsDetails { get; set; }
        #endregion

    }
}

