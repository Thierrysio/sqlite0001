using sqlite0001.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sqlite0001.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemView : ContentPage
    {
        public TodoItemView()
        {
            InitializeComponent();
            BindingContext = new TodoItemViewModel();
        }
    }
}