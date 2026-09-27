using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Checkout
{
    public class PaymentAuthorization
    {
        private bool _giftWrap;
        private readonly CheckoutBasket _checkoutBasket;
        private readonly CouponDiscount _couponDiscount;
        public PaymentAuthorization(CheckoutBasket CheckoutBasket, CouponDiscount CouponDiscount)
        {
            _checkoutBasket = CheckoutBasket;
            _couponDiscount = CouponDiscount;
        }
        public decimal GrandTotal()
        {
            var total = _checkoutBasket.SubTotal() - _couponDiscount.DiscountAmount();
            if (_giftWrap) total += 4.99m;
            return Math.Max(0m, total);
        }
    }
}
