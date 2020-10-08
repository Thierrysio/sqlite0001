using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace sqlite0001.Models
{
    public class Event
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        [ManyToMany(typeof(TodoItemEvent))] 
        public List<TodoItem> Participants { get; set; }
    }
}
