using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class ShoppingCartItem : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
