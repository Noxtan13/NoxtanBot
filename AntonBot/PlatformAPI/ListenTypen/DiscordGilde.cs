using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntonBot.PlatformAPI
{
    class DiscordGilde
    {
        public ulong ID { get; set; }
        public ulong OwnerID { get; set; }
        public string Name { get; set; }
        public List<DiscordServerChannel> Channels{ get; set; }
        public List <DiscordServerUser> Users { get; set; }
        public List <DiscordServerEmotes> Emotes { get; set; }
        public List <DiscordServerRoles> Roles { get; set; }
    }

    class DiscordServerChannel {
        public DiscordServerChannel(ulong id, string name)
        {
            ID = id;
            Name = name;
        }
        public ulong ID { get; set; }
        public string Name { get; set; }
    }

    class DiscordServerUser {
        public DiscordServerUser(ulong id, string name, bool isbot) {
            ID = id;
            Name = name;
            isBot = isbot;
        }
        public ulong ID { get; set; }
        public string Name { get; set; }
        public bool isBot { get; set; }

    }

    class DiscordServerEmotes {
        public DiscordServerEmotes(ulong id, string name)
        {
            ID = id;
            Name = name;
        }
        public ulong ID { get; set; }
        public string Name { get; set; }
    }

    class DiscordServerRoles {
        public DiscordServerRoles(ulong id, string name)
        {
            ID = id;
            Name = name;
        }
        public ulong ID { get; set; }
        public string Name { get; set; }
    }
}
