using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.UserLibraryHistory
{
    public class CreateUserLibraryHistoryDto
    {
        public int UserID { get; set; } // Foreign Key
        public int LibraryID { get; set; } // Foreign Key
        public string Action { get; set; } = string.Empty;
        public string Timestamp { get; set; } = string.Empty;
    }
}