namespace VR_Challange.Models
{
    public sealed class Box
    {
        public required string Id { get; init; }

        public string SupplierIdentifier { get; init; }

        public List<Content> Contents { get; } = [];
    }
}
