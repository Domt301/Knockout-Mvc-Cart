using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShoppingCart.ViewModels
{
    public class CartViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cartItems")]
        public virtual ICollection<CartItemViewModel> CartItems { get; set; }
    }
}