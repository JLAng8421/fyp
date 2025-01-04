using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserLibrarHistory
    {
        public int UserLibrarHistoryID { get; set; } // Primary Key
        public int UserID { get; set; } // Foreign Key
        public int LibraryID { get; set; } // Foreign Key
        public string Action { get; set; } = string.Empty;
        public string Timestamp { get; set; } = string.Empty;

        public User User { get; set; }

        public Library Library { get; set; }
    }
}