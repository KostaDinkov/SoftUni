namespace Empires.Objects.Resources
{
    public class Resource
    {
        public Resource(ResourceType type, int quantity)
        {
            this.Type = type;
            this.Quantity = quantity;
        }

        public ResourceType Type { get; set; }
        public int Quantity { get; set; }
    }
}