using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceGenerator
{
    public class Work
    {
        public int ID;
        public String name;
        public String publisher;
        public String release;
        public String location;
        public int vol;
        public int no;
        public String pp1;
        public String pp2;
        public String type;
        public String url;
        public IList<Author> authors;

        public Work()
        {
            authors = new List<Author>();
        }

        public Work(int id, String n, String p, String r, String location, int v, int no ,String p1, String p2, String t, String u)
        {
            authors = new List<Author>();
            this.ID = id;
            this.name = n;
            this.publisher = p;
            this.release = r;
            this.location = location;
            this.vol = v;
            this.no = no;
            this.pp1 = p1;
            this.pp2 = p2;
            this.type = t;
            this.url = u;
        }

    }
}
