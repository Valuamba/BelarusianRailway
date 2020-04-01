using Atata;

namespace RailwayBy.Pages
{
    using _ = PassangerPage;
    public class PassangerPage : Page<_>
    {
        //private TextBox LastNameBox = new TextBox("Last Name", By.XPath("//input[contains(@id,'lastname')]"));
        //private TextBox FirstNameBox = new TextBox("First Name", By.XPath("//input[contains(@id,'0:name')]"));
        //private TextBox PatronymicNameBox = new TextBox("Patronymic Name", By.XPath("//input[contains(@id,'patronymic')]"));
        //private TextBox DocumentNumberBox = new TextBox("Document number", By.XPath("//input[contains(@id,'docNum')]"));

        [FindById(TermMatch.EndsWith, "lastname")]
        public TextInput<_> LastName { get; private set; }

        [FindById(TermMatch.EndsWith, "0:name")]
        public TextInput<_> FirstName { get; private set; }

        [FindById(TermMatch.EndsWith, "patronymic")]
        public TextInput<_> PatronymicName { get; private set; }

        [FindById(TermMatch.EndsWith, "docNum")]
        public TextInput<_> DocumentNumber { get; private set; }

        [FindById(TermMatch.Contains, "18")]
        public Link<_> Seat { get; private set; }


        [FindByXPath("//input[@type='checkbox']")]
        public CheckBox<_> ConfirmBox { get; private set; }
    }
}
