using System;
using System.Linq;
using Orion.Core.Events;
using Orion.Core.Events.Players;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Players;
using Orion.Core.Utils;

namespace OrionShock
{
    internal sealed partial class EventHandlers
    {
        [EventHandler("orionshock-players", Priority = EventPriority.Normal)]
        public void HandlePlayerChat(PlayerChatEvent @event)
        {
        }
    }
}