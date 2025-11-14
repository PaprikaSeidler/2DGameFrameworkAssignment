
namespace Mandatory2DGameFramework.Worlds
{
    public class WorldObject
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public WorldObject()
        {
            Name = string.Empty;
            Lootable = false;
            Removeable = false;
            X = 0;
            Y = 0;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Lootable)}={Lootable.ToString()}, {nameof(Removeable)}={Removeable.ToString()}, {nameof(X)}={X.ToString()}, {nameof(Y)}={Y.ToString()}}}";
        }
    }
}
