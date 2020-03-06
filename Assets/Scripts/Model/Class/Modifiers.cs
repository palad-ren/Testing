using Assets.Scripts.Model.Interface;
namespace Assets.Scripts.Model.Class
{
    public class Modifiers : IModifiers
    {
        public string BringModifiers()
        {
            return "Modifiers";
        }
    }

    public class CharModifiers : IModifiers
    {
        public string BringModifiers()
        {
            return "CharModifiers";
        }
    }

    public class ItemModifiers : IModifiers
    {
        public string BringModifiers()
        {
            return "ItemModifiers";
        }
    }
}
