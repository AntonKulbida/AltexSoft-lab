using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MobileStore.Domain.Entities
{
    public class Mobile
    {
        [HiddenInput(DisplayValue=false)]
        public int MobileId { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage="Please, input name of product")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name="Description")]
        [Required(ErrorMessage = "Please, input description")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please,input category")]
        public string Category { get; set; }

        [Display(Name = "Price")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "You should input positive meaning of price")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
