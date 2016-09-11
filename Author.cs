using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceGenerator
{
    public class Author
    {
        public int AUTHOR_ID;
        public String name;
        public String surname;
        public String middleName;
        public int WORK_ID;

        public Author() { }
        public Author(int id,String n, String s, String m, int W_ID) 
        {
            AUTHOR_ID = id;
            name = n;
            surname = s;
            middleName = m;
            WORK_ID = W_ID;
        }
    }
}
