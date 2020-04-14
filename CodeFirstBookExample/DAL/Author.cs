using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstBookExample.DAL
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public string GhostWriter { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher {get; set;}
        public virtual ICollection<Book> Books { get; set; }
    }
}
