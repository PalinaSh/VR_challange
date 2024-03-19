namespace VR_Challange.Models
{
    public class Content
    {
        public required Guid Id { get; init; }

        public string ISBN { get; init; }

        public int Quantity { get; init; }

        public string PoNumber { get; init; } // If PO Number is always the same for entire Box then this property can be moved to Box class,
                                              // then there would be less similar data in Contents table.
    }
}
