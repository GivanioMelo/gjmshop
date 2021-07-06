using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckoutAPI.Domain
{
    [Table("cartItem")]
    public class CartItem
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
