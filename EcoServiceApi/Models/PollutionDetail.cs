using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoServiceApi.Models
{
    public class PollutionDetail
    {
        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollutionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime CreationDate { get; set; }

        #endregion

        #region FK

        [ForeignKey("UserId")]
        public UserDetail UserDetail { get; set; }

        #endregion

    }
}
