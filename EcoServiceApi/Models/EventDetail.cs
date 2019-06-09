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
        [Column(TypeName = "nvarchar(7)")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(7)")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(400)")]
        public string Description { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public float Latitude { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public float Longitude { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime EndDate { get; set; }

        #endregion

        #region FK

        [ForeignKey("UserId")]
        public UserDetail UserDetail { get; set; }

        #endregion

    }
}
