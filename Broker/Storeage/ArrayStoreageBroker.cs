using Book.CRUD.Models;
using System.Data.Common;

namespace Book.CRUD.Broker.Storeage
{
    internal class ArrayStoreageBroker : IStoreageBroker
    {
        private Books[] BooksInfo { get; set; } = new Books[10];
        public ArrayStoreageBroker()
        {
            BooksInfo[0] = new Books()
            {
                Id = 1,
                Name = "O'tgan kunlar",
                Author = "Abdulla Qodiriy"
            };
            BooksInfo[1] = new Books()
            {
                Id = 2,
                Name = "Shum bola",
                Author = "G'ofur G'ulom"
            };
        }
        public Books ReadBook(int id)
        {
            for(int itaration = 0; itaration < BooksInfo.Length; itaration++)
            {
                Books bookInfoLine = BooksInfo[itaration];
                if (bookInfoLine.Id == id)
                {
                    return bookInfoLine;
                }
            }
            return new Books();
        }
        public Books[] GetAllBook() => BooksInfo;
    }
}
