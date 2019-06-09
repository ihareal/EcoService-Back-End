using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoServiceApi.Models
{
    public class NewsDetail
    {
        #region Properties

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Description { get; set; }

        /// <summary>
        /// stored in minutes
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(4)")]
        public int ReadingTime { get; set; }

        /// <summary>
        /// 0 - doesn't read
        /// 1 - read
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(1)")]
        public int isRead { get; set; }

        #endregion

        #region FK

        public UserDetail UserDetail { get; set; }

        #endregion
    }
}
