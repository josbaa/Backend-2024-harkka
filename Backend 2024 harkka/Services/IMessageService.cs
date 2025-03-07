﻿using Backend_2024_harkka.Models;

namespace Backend_2024_harkka.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDTO>> GetMessagesAsync();
        Task<MessageDTO?> GetMessageAsync(long id);
        Task<MessageDTO> NewMessageAsync(MessageDTO message);
        Task<bool> UpdateMessageAsync(MessageDTO message);
        Task<bool> DeleteMessageAsync(long id);
    }
}
