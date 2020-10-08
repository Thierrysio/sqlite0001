using sqlite0001.Services;
using sqlite0001.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sqlite0001
{
    public partial class App : Application
    {
         static ItemsDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new TodoItemView();
        }

        public static ItemsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemsDatabase();
                }
                return database;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
