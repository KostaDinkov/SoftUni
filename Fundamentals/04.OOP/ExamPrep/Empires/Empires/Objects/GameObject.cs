namespace Empires.Objects
{
    using Utils;

    public abstract class GameObject
    {
        protected ulong id;

        protected GameObject()
        {
            this.id = IdGenerator.GenerateID();
        }
    }
}