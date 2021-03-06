﻿using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Map = Exiled.Events.Handlers.Map;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace CustomEscape
{
    public class CustomEscape : Plugin<Configs>
    {
        public override string Author { get; } = "Remindme";
        public override string Name { get; } = "Custom Escapes";
        public override string Prefix { get; } = "bEscape";
        public override Version Version { get; } = new Version(2, 4, 7);
        public override Version RequiredExiledVersion { get; } = new Version(2, 8, 0);
        public override PluginPriority Priority { get; } = PluginPriority.Highest;

        private EventHandlers EventHandlers { get; set; }

        public static CustomEscape Singleton;

        public override void OnEnabled()
        {
            Singleton = this;

            EventHandlers = new EventHandlers();

            Player.ChangingRole += EventHandlers.OnChangingRole;
            Player.Escaping += EventHandlers.OnEscaping;
            Map.Generated += EventHandlers.OnGenerated;
            Server.RoundEnded += EventHandlers.OnRoundEnded;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.ChangingRole -= EventHandlers.OnChangingRole;
            Player.Escaping -= EventHandlers.OnEscaping;
            Map.Generated -= EventHandlers.OnGenerated;
            Server.RoundEnded -= EventHandlers.OnRoundEnded;

            EventHandlers = null;

            Singleton = null;

            base.OnDisabled();
        }
    }
}
