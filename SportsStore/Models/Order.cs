using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> LinesCart { get; set; } = new List<CartLine>();

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ФИО")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название регион")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название города")]
        public string City { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название улицы")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите номер дома")]
        public string House { get; set; }

        public bool GiftWrap { get; set; }
    }
}
