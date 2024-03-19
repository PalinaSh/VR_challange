namespace VR_Challange.Models
{
    public sealed class Box
    {
        public string Id { get; set; }

        public string SupplierIdentifier { get; set; }

        public IReadOnlyCollection<Content> Contents { get; set; }
    }
}
