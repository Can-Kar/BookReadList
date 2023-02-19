using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadLibrary
{
    public class BookModel
    {
        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The author of the book
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Publisher of the book.
        /// </summary>
        public string Publisher { get; set; }

        public string FullInfo
        {
            get { return $"Kitap:{Title} , Yazar:{Author} , Yayinevi:{Publisher}"; }
        }

    }
}
