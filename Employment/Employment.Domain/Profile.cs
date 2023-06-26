using Employment.Common.Enums;
using Employment.Domain.BasesModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Employment.Domain
{
    public class Profile : DomainBaseEntity, IAuditable
    {
        public string Biography { get; set; }
        public bool IsCompleted { get; set; }
        public Gender? Gender { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public DateTime? DateTimeModified { get; set; }
        public DateTime? DateTimeDeleted { get; set; }


        #region Relations 


        public virtual User User { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual Resume Resume { get; set; }
        
        #endregion

    }
}
