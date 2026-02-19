using System;
using System.Collections.Generic;
using System.Text;

namespace library
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public Book(string _ISBN, string _Tiltle, string _Authors, DateTime _PublicationDate, decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Tiltle;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }

        public override string ToString()
        {
            return $"Book: ISBN: {ISBN} | Title: {Title} | Authors: {Authors} | PublicationDate: {PublicationDate} | Price: {Price}";
        }
    }
}
