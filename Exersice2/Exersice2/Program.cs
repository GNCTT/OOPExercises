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
            DocumentManager documentManager = new DocumentManager();
            while (true)
            {
                Console.WriteLine("App manage documents");
                Console.WriteLine("Type 1 to add book");
                Console.WriteLine("Type 2 to add magazine");
                Console.WriteLine("Type 3 to add paper");
                Console.WriteLine("Type 4 to show list documents");
                Console.WriteLine("Type 5 to search documents book");
                Console.WriteLine("Type 6 to search documents magazin");
                Console.WriteLine("Type 7 to search documents paper");
                Console.WriteLine("Type 8 to close app");

                var cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        {
                            Document doc = new Book();
                            doc.GetDataFromInput();
                            documentManager.AddDocument(doc);
                            break;
                        }
                    case "2":
                        {
                            Document doc = new Magazine();
                            doc.GetDataFromInput();
                            documentManager.AddDocument(doc);
                            break;
                        }
                    case "3":
                        {
                            Document doc = new Paper();
                            doc.GetDataFromInput();
                            documentManager.AddDocument(doc);
                            break;
                        }
                    case "4":
                        {
                            documentManager.ShowAllDocuments();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("List Book: ");
                            var docs = documentManager.SearchDucumentsByType<Book>();
                            foreach (var doc in docs)
                            {
                                Console.WriteLine(doc);
                            }
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("List magazin: ");
                            var docs = documentManager.SearchDucumentsByType<Magazine>();
                            foreach (var doc in docs)
                            {
                                Console.WriteLine(doc);
                            }
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("List paper: ");
                            var docs = documentManager.SearchDucumentsByType<Paper>();
                            foreach (var doc in docs)
                            {
                                Console.WriteLine(doc);
                            }
                            break;
                        }
                }
                Console.WriteLine("---------------------------");
                if (cmd == "8") break;
            }
        }
    }
}
