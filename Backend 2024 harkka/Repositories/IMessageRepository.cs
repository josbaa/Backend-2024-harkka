using Backend_2024_harkka;
using Backend_2024_harkka.Models;
namespace Backend_2024_harkka.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<IEnumerable<Message>> GetMySentMessagesAsync(User user);
        Task<IEnumerable<Message>> GetMyReceivedMessagesAsync(User user);
        Task<Message?> GetMessageAsync(long id);
        Task<Message?> NewMessageAsync(Message message);
        Task<bool> UpdateMessageAsync(Message message);
        Task<bool> DeleteMessageAsync(Message message);
    }
}