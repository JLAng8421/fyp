using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.UserLibraryHistory
{
    public class UserLibrarHistoryDto
    {
        public int UserLibrarHistoryID { get; set; } 
        public int UserID { get; set; } 
        public int LibraryID { get; set; } 
        public string Action { get; set; } = string.Empty;
        public string Timestamp { get; set; } = string.Empty;
    }
}