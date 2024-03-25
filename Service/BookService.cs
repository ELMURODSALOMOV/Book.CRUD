using Book.CRUD.Broker.Logging;
using Book.CRUD.Broker.Storeage;
using Book.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.CRUD.Service
{
    internal class BookService : IBookService
    {
        private readonly ILoggingBroker loggingBroker;
        private readonly IStoreageBroker storeageBroker;
        public BookService()
        {
            this.loggingBroker = new LoggingBroker();
            this.storeageBroker = new ArrayStoreageBroker();
        }
        public Books GetBook(int id)
        {
           Books book =  this.storeageBroker.ReadBook(id);
            return book;
        }

        public Books InsertBook(Books book)
        {
            var books =  this.storeageBroker.AddBook(book);
            if (book is null)
            {
                this.loggingBroker.LogError("Invalid informmation");
            }
            else
            {
                this.loggingBroker.LogInformation("Added new information.");
            }
            return books;
        }
            

        public Books[] ReadAllBook()
        {
            var bookInfo = this.storeageBroker.GetAllBook();
            if (bookInfo.Length is 0)
            {
                this.loggingBroker.LogError("Information not available.");
            }
            else
            {
                for (int itaration = 0; itaration < bookInfo.Length; itaration++)
                {
                    if (bookInfo[itaration] is not null)
                    {
                        this.loggingBroker.LogInformation($"{bookInfo[itaration].Id}.{bookInfo[itaration].Name} {bookInfo[itaration].Author}");
                    }
                }
            }
            return bookInfo;
        }

        public bool Update(int id, Books book)
        {
           return this.storeageBroker.Update(id, book);
        }
    }
}
