using System.Collections.Generic;
using MobileStore.Domain.Entities;
using MobileStore.Domain.Abstract;
using System.Web;

namespace MobileStore.Domain.Concrete
{
    public class EFMobileRepository : IMobileRepository
    {
        EFDbContext context;

        public EFMobileRepository()
        {
            string mdfFilePath = HttpContext.Current.Server.MapPath("~/App_Data/GameStore.mdf");
            context = new EFDbContext(string.Format(@"Data Source=.\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;User Instance=True", mdfFilePath));
        }

        public IEnumerable<Mobile> Mobiles
        {
            get { return context.Mobiles; }
        }

        public void SaveMobile(Mobile mobile)
        {
            if (mobile.MobileId == 0)
                context.Mobiles.Add(mobile);
            else
            {
                Mobile dbEntry = context.Mobiles.Find(mobile.MobileId);
                if (dbEntry != null)
                {
                    dbEntry.Name = mobile.Name;
                    dbEntry.Description = mobile.Description;
                    dbEntry.Price = mobile.Price;
                    dbEntry.Category = mobile.Category;
                    dbEntry.ImageData = mobile.ImageData;
                    dbEntry.ImageMimeType = mobile.ImageMimeType;
                }
            }
            context.SaveChanges();
        }


        public Mobile DeleteMobile(int mobileId)
        {
            Mobile dbEntry = context.Mobiles.Find(mobileId);
            if (dbEntry != null)
            {
                context.Mobiles.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
