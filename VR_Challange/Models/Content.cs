namespace VR_Challange.Models
{
    public class Content
    {
        public required Guid Id { get; init; }

        public string ISBN { get; init; }

        public int Quantity { get; init; }

        public string PoNumber { get; init; }
    }
}
