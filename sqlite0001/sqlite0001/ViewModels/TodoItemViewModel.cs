using sqlite0001.Models;
using sqlite0001.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;



namespace sqlite0001.ViewModels
{
    class TodoItemViewModel : INotifyPropertyChanged
    {
        #region Attributs
        private string _nom;
        private string _prenom;
        
        private List<TodoItem> _maListe;

        #endregion
        #region Constructeurs
        public TodoItemViewModel()
        {
            ActionAjout = new Command(ActionAjoutMethode);
        }

        #endregion
        #region Getters Setters
        public ICommand ActionAjout { get; }
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
                OnPropertyChanged(nameof(Nom));

            }
        }
            public List<TodoItem> MaListe
        {
            get
            {

                return _maListe;
            }

            set
            {
                _maListe = value;
                OnPropertyChanged(nameof(MaListe));
            }
        
    }
        public string Prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                _prenom = value;
                OnPropertyChanged(nameof(Prenom));

            }
        }
        #endregion
        #region Methodes
        public async void ActionAjoutMethode()
        {
            TodoItem _leTodoItem = new TodoItem();
            _leTodoItem.Nom = Nom;
            _leTodoItem.Prenom = Prenom;
            _leTodoItem.Done = true;
            await App.Database.SaveItemAsync(_leTodoItem);

            Event event1 = new Event();

            event1.Name = "fghjg";
            event1.Place = "bbbb";
            event1.Date = DateTime.Now;
            await App.Database.SaveItemAsyncEvent(event1);
            _leTodoItem.Events = new List<Event> { event1 };
            event1.Participants = new List<TodoItem> { _leTodoItem };
            await App.Database.toto(_leTodoItem);
            await App.Database.toto4(event1);


            var personStored = App.Database.TOTO2(_leTodoItem);

            var eventStored = App.Database.TOTO3(event1);

            MaListe = await App.Database.GetItemsAsync();
            TodoItem eventStored2 = await App.Database.TOTO2(MaListe[8]);

        }
        #endregion
        #region notifications
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
