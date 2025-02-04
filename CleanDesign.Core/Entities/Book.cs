using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsCheckedOut { get; private set; }
        
        public void CheckOut()
        {
            if (IsCheckedOut)
                throw new InvalidOperationException("This book is already checked out");

            IsCheckedOut = true;
        }

        public void CheckIn()
        {
            if (!IsCheckedOut)
                throw new InvalidOperationException("This book isn't checked out");

            IsCheckedOut = false;
        }
    }
}
