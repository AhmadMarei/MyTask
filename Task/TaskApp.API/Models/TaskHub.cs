using Microsoft.AspNetCore.SignalR;

namespace TaskApp.API.Models
{
    public class TaskHub:Hub
    {
        public async void refresh(){
            // In this method we can make one user  to refresh  by id eller  group of users  can refresh or
            //   all the user which have access can refresh
            // because this task is part of application so i make it for all clients which have access
            await Clients.All.SendAsync("refresh");
            
        }
    }
}