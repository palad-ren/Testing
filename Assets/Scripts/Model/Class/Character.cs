using Assets.Scripts.Model.Interface;
namespace Assets.Scripts.Model.Class
{
    public class Character
    {
        ICharacter _character;
        public Character()
        {
            IActions actions = new Actions();
            IActions charActions = new CharActions();
            IActions itremActions = new ItemActions();

            var result1 = actions.BringActions();
            var result2 = charActions.BringActions();
            var result3 = itremActions.BringActions();

        }
    }
}
