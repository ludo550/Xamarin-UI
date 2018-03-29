using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.UITest;
using Xamarin.UITest.Queries;


namespace Xam_Proj_Pages
{
    public class Test_Obj_iOs:Login_Interface
    {
        public Func<AppQuery, AppQuery> Username()
        {
            Func<AppQuery, AppQuery> UG = e => e.Text("WelcomeLabel");
            return UG;
        }
        public Func<AppQuery, AppQuery> Password()
        {
            Func<AppQuery, AppQuery> UG = e => e.Text("WelcomeLabel");
            return UG;
        }

        readonly IApp app;

        public Test_Obj_iOs(IApp App)
        {
            App = this.app;
        }

    }
}
