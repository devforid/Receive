using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Receive.Services;
using Repository.Models;
using Send.Services;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            ChatService chatService = new ChatService();

            Console.WriteLine("Enter your email");
            var userEmail = Console.ReadLine();
            Users userInfo = userService.IsValidUser(userEmail);
            if (userInfo == null)
            {
                Console.WriteLine("Please Signup to start chat.");
                Console.ReadKey();
                return;
            }
            if (userInfo.isLoggedin == false)
            {
                Console.WriteLine("Please login to start chat.");
                Console.ReadKey();
                return;
            }
            if(userInfo.isLoggedin == true)
            {
                Console.WriteLine("Waiting for sender response...");
            }
            chatService.subscribeToChat(userInfo);
            //new Thread(() =>
            //{
            //    chatService.subscribeToChat(userInfo);

            //}).Start();

            //Task task = Task.Run(() =>);
            //Console.ReadLine();
        }

       
    }
}
