namespace SrpLab;

public sealed class PickerInstruction
{
    private readonly WarehouseWalkingRoute _route;
    private readonly StockAllocator _allocator;

    public PickerInstruction(
        WarehouseWalkingRoute route,
        StockAllocator allocator)
    {
        _route = route;
        _allocator = allocator;
    }

    public string PickerScript(
        WarehousePickList pickList)
    {
        var steps =
            _route.WalkingOrder(pickList)
                .Select(
                    (s, i) =>
                        $"{i + 1}. " +
                        $"Go aisle {s.Aisle} " +
                        $"bin {s.Bin}: " +
                        $"pick {s.Qty} × {s.Sku}");

        var shortfalls =
            _allocator
                .Allocate(pickList)
                .Where(a =>
                {
                    var need =
                        pickList.Lines
                            .First(l =>
                                l.Sku == a.Sku)
                            .QtyNeeded;

                    return a.Allocated < need;
                });

        var warning =
            shortfalls.Any()
                ? "SHORTAGES: " +
                  string.Join(
                      ", ",
                      shortfalls.Select(
                          s => s.Sku))
                : "SHORTAGES: none";

        return
            string.Join('\n', steps) +
            "\n" +
            warning;
    }
}