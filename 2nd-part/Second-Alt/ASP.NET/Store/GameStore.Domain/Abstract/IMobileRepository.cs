using System.Collections.Generic;
using MobileStore.Domain.Entities;

namespace MobileStore.Domain.Abstract
{
    public interface IMobileRepository
    {
        IEnumerable<Mobile> Mobiles { get; }
        void SaveMobile(Mobile game);
        Mobile DeleteMobile(int gameId);
    }
}
