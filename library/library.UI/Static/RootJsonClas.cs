using library.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.UI.Static
{
    public class RootJsonClas
    {
        public string bookname { get; set; }
        public DateTime? releasedate { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
    }
    public class Root
    {
        public RootJsonClas[] root { get; set; }
    }
}
