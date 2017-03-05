using System.Collections.Generic;
using System.Linq;

namespace MobileStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Mobile mobile, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Mobile.MobileId == mobile.MobileId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Mobile = mobile,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Mobile mobile)
        {
            lineCollection.RemoveAll(l => l.Mobile.MobileId == mobile.MobileId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Mobile.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Mobile Mobile { get; set; }
        public int Quantity { get; set; }
    }
}
