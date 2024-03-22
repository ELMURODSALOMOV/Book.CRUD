
using Book.CRUD.Models;

namespace Book.CRUD.Broker.Storeage
{
    interface IStoreageBroker
    {
        Books ReadBook(int id);
        Books[] GetAllBook();
    }
}
