using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Domain
{
    public class ConfirmationEmail
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime DateTimeSent { get; set; } = DateTime.Now;
        public bool IsConfirmed { get; set; }   
        public DateTime? DateTimeConfirmed { get; set; }


        #region Relations 

        public virtual User User { get; set; }
        public string UserId { get; set; }

        #endregion

    }
}
