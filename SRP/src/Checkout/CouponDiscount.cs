using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Checkout
{
    internal class CouponDiscount
    {
        private string? _couponRaw;
        private readonly CheckoutBasket _checkoutBasket;
        public CouponDiscount(CheckoutBasket CheckoutBasket)
        {
            _checkoutBasket = CheckoutBasket;
        }
        public void ApplyCouponText(string? couponText) => _couponRaw = couponText;
        public decimal DiscountAmount()
        {
            if (string.IsNullOrWhiteSpace(_couponRaw)) return 0m;
            var t = _couponRaw.Trim().ToUpperInvariant();
            if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
                return Math.Round(_checkoutBasket.SubTotal() * pct / 100m, 2);
            if (t.Contains("FREESHIP")) return 0m; 
            if (t == "WELCOME10") return Math.Min(10m, _checkoutBasket.SubTotal());
            return 0m;
        }
    }
}
