namespace SrpLab;

public sealed class StockAllocator
{
    public IReadOnlyList<
        (string Sku, int Allocated)>
        Allocate(
            WarehousePickList pickList)
    {
        var result =
            new List<(string, int)>();

        foreach (var line in pickList.Lines)
        {
            var allocated =
                Math.Min(
                    line.QtyNeeded,
                    line.QtyOnHand);

            result.Add(
                (line.Sku, allocated));
        }

        return result;
    }
}