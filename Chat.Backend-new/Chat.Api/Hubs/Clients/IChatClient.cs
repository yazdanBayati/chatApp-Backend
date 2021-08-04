using Chat.ApplicationService.Dtos;
using System.Threading.Tasks;

namespace Chat.Api.Hubs.Clients
{
    /// <summary>
    /// send data to client
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// send meesage to clinet
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task ReceiveMessage(ChatMessageDto message);

        /// <summary>
        /// notify the clients about new group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        Task AddGroup(ChatGroupDto group);// will check already group exists or not

        /// <summary>
        /// notify all user from new user join
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task JoinUserToGroup(string userName);

    }
}
