using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace sqlite0001.Models
{
    public class TodoItemEvent
    {
        [ForeignKey(typeof(TodoItem))] 
        public int Id { get; set; }
        [ForeignKey(typeof(Event))] 
        public int EventId { get; set; }
    }
}
