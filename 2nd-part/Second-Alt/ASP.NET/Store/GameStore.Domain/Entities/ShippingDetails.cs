using System.ComponentModel.DataAnnotations;

namespace MobileStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Input your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Input address of delivery")]
        [Display(Name="First address")]
        public string Line1 { get; set; }

        [Display(Name = "Second address")]
        public string Line2 { get; set; }

        [Display(Name = "Third address")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Point town")]
        [Display(Name = "Town")]
        public string City { get; set; }

        [Required(ErrorMessage = "Point country")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
