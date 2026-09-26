namespace OOP_Assignment_2.src.Kitchen
{
    public class KitchenTicketPrinter
    {
        private readonly AllergenDetector _allergenDetector;
        private readonly KitchenReadyTimeEstimator _estimator;

        public KitchenTicketPrinter(
            AllergenDetector allergenDetector,
            KitchenReadyTimeEstimator estimator)
        {
            _allergenDetector = allergenDetector;
            _estimator = estimator;
        }

        public string RenderThermalTicket(
            KitchenOrder order,
            int orderNumber)
        {
            var width = 32;
            var line = new string('=', width);

            var body = string.Join(
                '\n',
                order.Items.Select(i =>
                    $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));

            var allergens =
                _allergenDetector.DetectAllergens(order);

            var allergyLine = allergens.Count == 0
                ? "ALLERGENS: none"
                : "ALLERGENS: " + string.Join(",", allergens);

            return
                $"{line}\n" +
                $"ORDER #{orderNumber}\n" +
                $"ETA {_estimator.EstimatedReadyMinutes(order, 2)} MIN\n" +
                $"{body}\n" +
                $"{allergyLine}\n" +
                $"{line}\n";
        }
    }
}