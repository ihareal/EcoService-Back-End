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
        public int UserId { get; set; }
        public UserDetail UserDetail { get; set; }

        public int NewsId { get; set; }
        public NewsDetail NewsDetail { get; set; }
    }
}
