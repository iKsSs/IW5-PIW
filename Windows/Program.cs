using System;
using System.Data.Entity;
using Windows.Windows;
using Data;
using Services;

namespace Windows
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Database.SetInitializer(new DefaultDataLocalDbContext());  //TODO 
            var container = SimpleInjector.Booster();
            var app = new App();
            var mainWindow = container.GetInstance<MainWindow>();
            app.Run(mainWindow);
        }
    }
}
