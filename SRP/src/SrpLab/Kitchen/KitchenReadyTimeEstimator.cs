namespace OOP_Assignment_2.src.Kitchen
{
    public class KitchenReadyTimeEstimator
    {
        private readonly AllergenDetector _allergenDetector;

        public KitchenReadyTimeEstimator(
            AllergenDetector allergenDetector)
        {
            _allergenDetector = allergenDetector;
        }

        public int EstimatedReadyMinutes(
            KitchenOrder order,
            int openStations)
        {
            if (openStations <= 0)
                openStations = 1;

            var sequential =
                order.Items.Sum(i => i.PrepMinutes);

            var parallel =
                (int)Math.Ceiling(
                    sequential / (double)openStations);

            if (_allergenDetector
                .DetectAllergens(order).Count > 0)
            {
                parallel += 3;
            }

            var longest = order.Items.Count == 0
                ? 0
                : order.Items.Max(i => i.PrepMinutes);

            return Math.Max(parallel, longest);
        }
    }
}