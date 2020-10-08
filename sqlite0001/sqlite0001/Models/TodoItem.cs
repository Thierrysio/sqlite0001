using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace sqlite0001.Models
{
   [Table("TodoItem")]
    public class TodoItem
    {
        #region Attributs - Getters Setters
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool Done { get; set; }
        
        [ManyToMany(typeof(TodoItemEvent))] 
        public List<Event> Events { get; set; }
        
        #endregion
    }
}
