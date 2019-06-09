using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoServiceApi.Models
{
    public class EventDetail
    {
        /// <summary>
        /// Status - 0(pending) 1(approved by admin) 2(end)
        /// Event connected with user from one to many
        /// </summary>
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
     
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public string Status { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime CreationDate { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime EndDate { get; set; }

        #endregion

        #region FK

        [ForeignKey("UserId")]
        public UserDetail UserDetail { get; set; }

        #endregion

    }
}
