using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceGenerator
{
    class Work
    {
        private int ID;
        private String name;
        private String publisher;
        private String release;
        private int vol;
        private int no;
        private String pp1;
        private String pp2;
        private String type;
        private String url;

        public Work(int id, String n, String p, String r, int v, int no ,String p1, String p2, String t, String u)
        {
            this.ID = id;
            this.name = n;
            this.publisher = p;
            this.release = r;
            this.vol = v;
            this.no = no;
            this.pp1 = p1;
            this.pp2 = p2;
            this.type = t;
            this.url = u;
        }

    }
}
