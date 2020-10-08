using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using sqlite0001.Models;

namespace sqlite0001.Services
{
    public class ItemsDatabase
    {
        #region Attributs
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        #endregion
        #region Constructeurs
        public ItemsDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        #endregion
        #region Methodes
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
        });
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(TodoItem).Name))
                {
                    
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TodoItem)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Event)).ConfigureAwait(false);
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(TodoItemEvent)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<TodoItem>> GetItemsAsync()
        {
            
            return Database.Table<TodoItem>().ToListAsync();
        }

        public Task<List<TodoItemEvent>> GetItemsAsyncTodoItemEvent()
        {

            return Database.Table<TodoItemEvent>().ToListAsync();
        }

        public Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }
         
        public Task<TodoItem> GetItemAsync(int id)
        {
            return Database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }
        public Task<int> SaveItemAsyncEvent(Event item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync( TodoItem item)
        {
            return Database.DeleteAsync(item);
        }
        public Task  toto4(Event item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }
        public Task toto(TodoItem item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }

        public Task<TodoItem> TOTO2(TodoItem item)
        {
            return Database.GetWithChildrenAsync<TodoItem>(item.ID);
        }

        public Task<Event> TOTO3(Event item)
        {
            return Database.GetWithChildrenAsync<Event>(item.Id);
        }

        #endregion
    }
}
