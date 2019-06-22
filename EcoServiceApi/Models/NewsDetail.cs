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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime Date { get; set; }

        #endregion

        #region FK

        /// <summary>
        /// Many to many with users
        /// </summary>
        public List<UserNewsDetail> UserNewsDetails { get; set; }

        #endregion
    }
}
