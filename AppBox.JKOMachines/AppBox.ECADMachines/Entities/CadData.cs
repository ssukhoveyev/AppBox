using AppBox.JKOMachines.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.ECADMachines.Entities
{
    public class CadData
    {
        public List<Whip> whips;

        public CadData() { 
            whips = new List<Whip>();
        }
    }
}
