using System;
using System.Diagnostics;
using System.Linq;
using Orion.Core.Events;
using Orion.Core.Events.Server;
using OrionShock.Commands;
using OrionShock.Exceptions;

namespace OrionShock
{
    internal sealed partial class EventHandlers
    {
        [EventHandler("orionshock-playerchat", Priority = EventPriority.Normal)]
        public void HandleServerChat(ServerCommandEvent @event)
        {
        }
    }
}