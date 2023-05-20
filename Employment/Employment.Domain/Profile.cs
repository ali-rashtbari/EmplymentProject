using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Employment.Domain
{
    public class Profile : DomainBaseEntity
    {
        public string Biography { get; set; }
        public bool IsCompleted { get; set; }
        #region Relations 


        public virtual User User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }


        public virtual Resume Resume { get; set; }
        [ForeignKey(nameof(Resume))]
        public int? ResumeId { get; set; }


        #endregion

    }
}
