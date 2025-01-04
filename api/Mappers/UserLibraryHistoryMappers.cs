using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.UserLibraryHistory;
using api.Models;

namespace api.Mappers
{
    public static class UserLibrarHistoryMappers
    {
        public static UserLibrarHistoryDto ToUserLibrarHistoryDto(this UserLibrarHistory historyModel)
        {
            return new UserLibrarHistoryDto
            {
                UserLibrarHistoryID = historyModel.UserLibrarHistoryID,
                UserID = historyModel.UserID,
                LibraryID = historyModel.LibraryID,
                Action = historyModel.Action,
                Timestamp = historyModel.Timestamp,
            };
        }

        public static UserLibrarHistory ToCreateUserLibraryHistoryDto(this CreateUserLibraryHistoryDto historyDto)
        {
            return new UserLibrarHistory
            {
                UserID = historyDto.UserID,
                LibraryID = historyDto.LibraryID,
                Action = historyDto.Action,
                Timestamp = historyDto.Timestamp,
            };
        }
    }
}