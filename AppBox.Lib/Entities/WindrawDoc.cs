using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib.Entities
{
    public class WindrawDoc
    {
        public int id;
        public string name;

        public virtual void Remove()
        {
            throw new NotImplementedException();
        }
    }

    public class DocOper
    {
        public int id;
        public string name;

        public DocOper(DataRow dr) {
            id = Convert.ToInt32(dr[0]);
            name = dr[1].ToString();
        }
    }

    public class DocState
    {
        public int id;
        public string name;

        public DocState(DataRow dr)
        {
            id = Convert.ToInt32(dr[0]);
            name = dr[1].ToString();
        }
    }
}
