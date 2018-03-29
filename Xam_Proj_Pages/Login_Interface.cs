using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Queries;

namespace Xam_Proj_Pages
{
    public interface Login_Interface
    {
        Func<AppQuery, AppQuery> Username();
        Func<AppQuery, AppQuery> Password();

    }
}
