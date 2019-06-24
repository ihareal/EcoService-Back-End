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
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
     
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

        public List<UserEventDetail> UserEventDetail { get; set; }

        #endregion

    }
}
