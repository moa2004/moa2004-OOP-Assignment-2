namespace OOP_Assignment_2.src.Kitchen
{
    public class ExpoLaneSelector
    {
        private readonly AllergenDetector _allergenDetector;
        private readonly KitchenReadyTimeEstimator _estimator;

        public ExpoLaneSelector(
            AllergenDetector allergenDetector,
            KitchenReadyTimeEstimator estimator)
        {
            _allergenDetector = allergenDetector;
            _estimator = estimator;
        }

        public string ExpoLaneHint(KitchenOrder order)
        {
            if (_allergenDetector
                .DetectAllergens(order).Count > 0)
            {
                return "LANE-ALLERGY";
            }

            return _estimator
                .EstimatedReadyMinutes(order, 2) > 20
                    ? "LANE-SLOW"
                    : "LANE-FAST";
        }
    }
}