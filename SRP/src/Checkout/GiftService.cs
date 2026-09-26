using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Checkout
{
    public class GiftService
    {
        private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
        private bool _giftWrap;
        private readonly PaymentAuthorization _paymentAuthorization;
        public GiftService(PaymentAuthorization paymentAuthorization) {
            _paymentAuthorization = paymentAuthorization;
        }
        public void EnableGiftWrap() => _giftWrap = true;
        public string GiftMessageCard(string fromName)
        {
            var items = string.Join(", ", _lines.Select(l => l.Sku));
            return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {_paymentAuthorization.GrandTotal():C}\n";
        }
    }
}
