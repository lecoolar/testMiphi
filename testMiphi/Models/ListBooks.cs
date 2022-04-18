using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testMiphi.Models
{
    public class ListBooks
    {
        public List<Book> books { get; set; }
        public ListBooks()
        {
            books = new List<Book>() {
            new Book(1,"автор1","издатель1","раздел1",true,"оценка1"),
            new Book(2,"автор2","издатель2","раздел2",false,"оценка2"),
            new Book(3,"автор3","издатель3","раздел3",true,"оценка3"),
            new Book(4,"автор4","издатель4","раздел4",false,"оценка4"),
            new Book(5,"автор5","издатель5","раздел5",true,"оценка5")
            };
        }
    }
}
