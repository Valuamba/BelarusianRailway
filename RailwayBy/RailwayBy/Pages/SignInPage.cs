using System;
using System.Collections.Generic;
using System.Text;
using Atata;
namespace RailwayBy.Pages
{
    using _ = SignInPage;

    [Url("wps/portal/home/rp")]
    public class SignInPage : Page<_>
    {
        [FindByXPath("//a[contains(@onclick, 'login_main')]")]
        public Text<_> Signin { get; private set; }
    }
}
