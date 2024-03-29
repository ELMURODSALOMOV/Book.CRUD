using Book.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.CRUD.Service
{
    internal interface IBookService
    {
        Books GetBook(int id);
        Books[] ReadAllBook();
        Books InsertBook(Books book);
        bool Update(Books book);
        bool Delete(int id);
    }
}
