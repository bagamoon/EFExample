using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure.Interception;
using ExampleApplicationCSharp.Logging;
using LibDataAccess.DAL;

namespace ExampleApplicationCSharp
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            LoggingForm frmLogging = new LoggingForm();
            frmLogging.Show();
#endif

            //加入Entity Framework的sql cmd logger
            DbInterception.Add(new LoggerCommandInterceptor());

            log4net.Config.XmlConfigurator.Configure();

            Application.Run(new MainForm());
            
        }
    }
}
