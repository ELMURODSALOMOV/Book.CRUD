using System;
using Book.CRUD.Broker.Storeage;
using Book.CRUD.Models;
using Book.CRUD.Service;

IBookService bookService = new BookService();
bool isContinue = true;
do
{
    Console.WriteLine("1. Get All Book");
    Console.WriteLine("2. Add Book");
    Console.WriteLine("3. Update one book");
    Console.WriteLine("4. Delete one book");
    Console.WriteLine("5. Get book");
    Console.Write("Enter command ");
    string command = Console.ReadLine();
    if(command.Contains("2") is true)
    {
        Books books = new Books();
        Console.Write("Enter the Id ");
        books.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter name ");
        books.Name = Console.ReadLine();
        Console.Write("Enter Author ");
        books.Author = Console.ReadLine();
        bookService.InsertBook(books);
    }
    if(command.Contains("1") is true)
    {
        bookService.ReadAllBook();
    }
    if(command.Contains("3") is true)
    {
        Books book1 = new Books();
        Console.Write("Enter the Id ");
        book1.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter name ");
        book1.Name = Console.ReadLine();
        Console.Write("Enter Author ");
        book1.Author = Console.ReadLine();
        bookService.Update(book1);
    }
    if(command.Contains("4") is true)
    {
        Console.Write("Enter the Id to delete ");
        int id =  Convert.ToInt32(Console.ReadLine());
        bookService.Delete(id);
    }
    if(command.Contains("5") is true)
    {
        Console.WriteLine("Enter id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        bookService.GetBook(id);
    }
    Console.Write("Is Continue ");
    string isCommand = Console.ReadLine();
    if(isCommand.ToLower().Contains("no") is true)
    {
        isContinue = false;
    }
} while (isContinue is true);