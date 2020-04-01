using Atata;

namespace RailwayBy.Pages
{
    using _ = CheckOrderPage;
    public class CheckOrderPage : Page<_>
    {
        [Term("Продолжить")]
        public Button<_> Continue { get; private set; }
    }
}
