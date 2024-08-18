using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Document book = new Book(1, "ABC", 1, "ABC", 11);
            Document paper = new Paper(2, "ABC", 2, 2, 1);

            DocumentManager manager = new DocumentManager();
            manager.AddDocument(book);
            manager.AddDocument(paper);
            manager.AddDocument(book);

            manager.ShowAllDocuments();

            var documents = manager.SearchDucumentsByType<Book>();
            foreach (var document in documents)
            {
                manager.ShowDocumentInfo(document);
            }
        }
    }
}
