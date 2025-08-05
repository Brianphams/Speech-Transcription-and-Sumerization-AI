using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SpetoTex.Hubs
{
    public class VideoProcessingHub : Hub
    {
        public async Task JoinGroup(string jobId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, jobId);
        }
    }
}