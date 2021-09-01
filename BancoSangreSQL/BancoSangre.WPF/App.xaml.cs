using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BancoSangre.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App ()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDIxMDQyQDMxMzkyZTMxMmUzMEFVMzljY3NLcEdWZW5vazlKMHRCTEJyRVN6YjcwMGJvTCtZaFFhZnVUclk9");
            Bold.Licensing.BoldLicenseProvider.RegisterLicense("j+XOxALjqcx/COVqbGD+dgoL2rli1zwOx2/6YBmWCSQ=");
        }

    }
}
