using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Steam.Models.SteamCommunity;

namespace Steam_Linker_2._0
{
    public class FriendModelComparer : IEqualityComparer<FriendModel>
    {
        public bool Equals(FriendModel x, FriendModel y)
        {
            if (x == null)
                return y == null;

            if (y == null)
                return false;

            return x.SteamId == y.SteamId;
        }

        public int GetHashCode(FriendModel obj)
        {
            if (obj == null)
                return 0;
            return obj.SteamId.GetHashCode();
        }
    }
}
