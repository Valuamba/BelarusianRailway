using Atata;
using RailwayBy.Pages.Helper;

namespace RailwayBy.Pages
{

    using _ = ComplitePage;
    public class ComplitePage : Page<_>
    {
        
        [FindById("viewns_Z7_9HD6HG80NGMO80ABJ9NPD12001_:confirm:form1:tbody_element")]
        public Table<PaymentMethod,_> PaymentTable { get; private set; }

        
        public class PaymentMethod : TableRow<_>
        {
            [FindByRowSpannedCellIndex(0)]
            public RadioButton<_> RadioButton { get; private set; }

            [FindByRowSpannedCellIndex(1)]
            public Text<_> Method { get; private set; }

            //public Content<_> CardMethod { get; private set; }
        }
    }
}
