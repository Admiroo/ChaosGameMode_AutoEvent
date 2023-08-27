using ChaosGameMode_AutoEvent.Handlers;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace ChaosGameMode_AutoEvent
{
    public class ChaosGameMode : Plugin<Config>
    {
        private static readonly Lazy<ChaosGameMode> Newinstance = new Lazy<ChaosGameMode>(valueFactory: () => new ChaosGameMode());
        public static ChaosGameMode Instance => Newinstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private EventHandlers player;
        private EventHandlers server;

        private ChaosGameMode()
        {
        }
        public override void OnEnabled()
        {
            RegisterEvents();
        }
        public override void OnDisabled()
        {
            UnRegisterEvents();
        }
        public void RegisterEvents()
        {
            server = new EventHandlers();

            Server.RoundStarted += server.OnEventStart;
            Server.RoundEnded += server.EndEvent;
            Server.RestartingRound += server.EventEndOnRoundRestarted;
        }
        public void UnRegisterEvents()
        {
            Server.RoundStarted -= server.OnEventStart;
            Server.RoundEnded -= server.EndEvent;
            Server.RestartingRound -= server.EventEndOnRoundRestarted;

            server = null;
        }
    }
}
