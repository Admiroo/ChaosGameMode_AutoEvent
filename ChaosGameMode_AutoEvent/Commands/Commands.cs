using EventHandlers = ChaosGameMode_AutoEvent.Handlers.EventHandlers;
using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Enums;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ChaosGameMode_AutoEvent.Commands
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Commands : ICommand
    {
        public string Command { get; } = "ChaosGameMode Start";

        public string[] Aliases { get; } = {"chaosgamemode"};

        public string Description { get; } = "starts the Chaos GameMode event";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is CommandSender)
            {
                if (RoundSummary.RoundInProgress() == false)
                {
                    response = "Starting Chaos GameMode Event Next Round...";
                    EventHandlers.StartEvent();
                    return true;
                }
                else
                {
                    response = "Can't iniciate Chaos GameMode event while round is in progress.";
                    return false;
                }
            }
            else
            {
                response = "You do not have permission to use this command";
                return false;
            }
        }
    }
}
