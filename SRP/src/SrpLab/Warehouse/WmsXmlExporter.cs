namespace SrpLab;

public sealed class WmsXmlExporter
{
    private readonly StockAllocator _allocator;

    public WmsXmlExporter(
        StockAllocator allocator)
    {
        _allocator = allocator;
    }

    public string WmsXmlBatch(
        WarehousePickList pickList,
        string batchId)
    {
        var parts =
            _allocator
                .Allocate(pickList)
                .Select(
                    a =>
                        $"<line sku=\"{a.Sku}\" " +
                        $"qty=\"{a.Allocated}\" />");

        return
            $"<batch id=\"{batchId}\">" +
            $"{string.Join("", parts)}" +
            $"</batch>";
    }
}