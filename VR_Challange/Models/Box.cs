namespace VR_Challange.Models
{
    public sealed class Box
    {
        public string SupplierIdentifier { get; set; }

        public string Identifier { get; set; }

        public IReadOnlyCollection<Content> Contents { get; set; }
    }
}
