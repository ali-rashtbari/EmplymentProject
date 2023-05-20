﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;


        #region Relations 

        public virtual Profile Profile { get; set; }
        [ForeignKey(nameof(Profile))]
        public int ProfileId { get; set; }

        #endregion
    }
}
