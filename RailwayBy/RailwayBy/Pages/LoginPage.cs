using Atata;

namespace RailwayBy.Pages
{
    using _ = LoginPage;
    public class LoginPage : Page<_>
    {
        [FindById]
        public TextInput<_> Login { get; private set; }

        [FindById]
        public PasswordInput<_> Password { get; private set; }

        [FindByClass("commandExButton")]
        public Button<_> CommandExButton { get; private set; }

        [FindByXPath("//input[@type='checkbox']")]
        public CheckBox<_> ConfirmBox { get; private set; }
    }
}
