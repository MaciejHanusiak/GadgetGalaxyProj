using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GadgetGalaxyDatabase;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var context = new GGDbContext())
            {
                context.Database.Migrate();
                var dbfill = new SeedDbData();
                dbfill.SeedDatabase(context);
            }
        }
    }
}
