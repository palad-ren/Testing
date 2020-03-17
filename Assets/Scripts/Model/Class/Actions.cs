using Assets.Scripts.Model.Interface;
namespace Assets.Scripts.Model.Class
{
    public class Actions : IActions
    {
        public virtual string BringActions()
        {
            return "Actions";
        }
    }

    public class CharActions : Actions
    {
        public override string BringActions()
        {
            return base.BringActions() + "CharActions";
        }
    }

    public class ItemActions : Actions
    {
        public override string BringActions()
        {
            return base.BringActions() + "ItemActions";
        }
    }
}
