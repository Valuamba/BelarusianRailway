using Atata;

namespace RailwayBy.Pages
{
    using _ = CarsPage;
    public class CarsPage : Page<_>
    {
        [FindByContentOrValue("Выбрать")]
        public Button<PassangerPage, _> Submit { get; private set; }
    }
}
