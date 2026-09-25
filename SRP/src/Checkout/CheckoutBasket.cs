using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Assignment_2.src.Checkout
{
    internal class CheckoutBasket
    {
        private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
        public void AddLine(string sku, decimal price, int qty)
        {
            if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
            _lines.Add((sku, price, qty));
        }
        public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);
    }
}
