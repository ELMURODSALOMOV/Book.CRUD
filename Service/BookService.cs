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

        public bool Delete(int id)
        {
            return id is 0
                   ? InvalidDeleteId()
                   : ValidationAndDelete(id);
        }


        public Books GetBook(int id)
        {
           Books book =  this.storeageBroker.ReadBook(id);
            return book;
        }

        public Books InsertBook(Books book)
        {
            return book is null
                   ? InsertBookIsInvalid()
                   : ValidationAndInsertBook(book);
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
        private Books ValidationAndInsertBook(Books book)
        {
            if (book.Id is 0
                || String.IsNullOrWhiteSpace(book.Name)
                || String.IsNullOrWhiteSpace(book.Author))
            {
                this.loggingBroker.LogError("Invalid books information");
                return new Books();
            }
            else
            {
                var bookInformation = this.storeageBroker.AddBook(book);
                if(bookInformation is null)
                {
                    this.loggingBroker.LogInformation("Not Added book Info.");
                }
                else
                {
                    this.loggingBroker.LogInformation("Secssesfull.");
                }
                return bookInformation;
            }
        }
        private bool ValidationAndDelete(int id)
        {
            bool isDelete = this.storeageBroker.Delete(id);
            if(isDelete is true)
            {
                this.loggingBroker.LogInformation("The information in the id has been deleted.");
                return isDelete;
            }
            else
            {
                this.loggingBroker.LogError("Id is Not Found.");
                return isDelete;
            }
        }

        private bool InvalidDeleteId()
        {
            this.loggingBroker.LogError("The id information is invalid.");
            return false;
        }

        private Books InsertBookIsInvalid()
        {
            this.loggingBroker.LogError("Book info is null.");
            return new Books();
        }
    }
}
