using System.Collections.Generic;
using MobileStore.Domain.Entities;

namespace MobileStore.WebUI.Models
{
    public class MobilesListViewModel
    {
        public IEnumerable<Mobile> Mobiles { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}