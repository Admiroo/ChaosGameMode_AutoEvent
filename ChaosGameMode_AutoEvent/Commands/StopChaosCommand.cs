using CommandSystem;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using EventHandlers = ChaosGameMode_AutoEvent.Handlers.EventHandlers;
namespace ChaosGameMode_AutoEvent.Commands
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class StopChaosCommand : ICommand
    {
        public string Command { get; } = "StopChaoticState";

        public string[] Aliases { get; } = { "stopchaos" };

        public string Description { get; } = "Stop the chaotic state";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is CommandSender)
            {
                response = "The Chaotic State Has Gone...";
                EventHandlers.StopChaoticStateCommand();
                return true;
            }
            else
            {
                response = "You do not have permission to use this command";
                return false;
            }
        }
    }
}
