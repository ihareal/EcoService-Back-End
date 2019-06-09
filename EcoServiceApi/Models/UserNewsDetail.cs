using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoServiceApi.Models
{
    public class UserNewsDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int UserId { get; set; }
        public NewsDetail NewsDetail { get; set; }

        public int NewsId { get; set; }
        public UserDetail UserDetail { get; set; }
    }
}
