using System;
using System.Collections.Generic;
using System.Linq;

namespace Exersice2
{
    public class DocumentManager
    {
        private readonly List<Document> _documents = new List<Document>();

        public void AddDocument(Document document)
        {
            if (!IsContainSameCode(document.Code))
            {
                _documents.Add(document);
                Console.WriteLine("Add document with info: {0} Succesfully!!", document);
                return;
            }
            Console.WriteLine("Code: {0} is used", document.Code);
        }

        private bool IsContainSameCode(int code)
        {
            var document = _documents.FirstOrDefault(d => d.Code == code);
            if (document == null) return false;
            return true;
        }

        public void RemoveDocumentByCode(int code) {
            var document = _documents.FirstOrDefault(d => d.Code == code);
            if (document != null)
            {
                _documents.Remove(document);
                return;
            }
            Console.WriteLine("Do not have document to remove");
        }

        public void ShowDocumentInfo(Document document)
        {
            Console.WriteLine(document);
        }

        public void ShowAllDocuments()
        {
            Console.WriteLine("List Document: ");
            foreach (var document in _documents)
            {
                Console.WriteLine(document);
            }
        }

        public List<Document> SearchDucumentsByType<T>() where T : Document
        {
            List<Document> list = new List<Document>();
            foreach (var document in _documents)
            {
                if (document as T != null)
                {
                    list.Add(document);
                }
            }
            return list;
        }

        public void ExitProgram()
        {
            Console.WriteLine("Exit Program");
        }

    }
}
