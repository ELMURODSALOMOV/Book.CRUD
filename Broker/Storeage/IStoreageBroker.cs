﻿
using Book.CRUD.Models;

namespace Book.CRUD.Broker.Storeage
{
    interface IStoreageBroker
    {
        Books ReadBook(int id);
        Books[] GetAllBook();
        Books AddBook(Books book);
        bool Update(int id, Books book);
    }
}
