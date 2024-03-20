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
    }
}
