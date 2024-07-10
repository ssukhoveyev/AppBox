using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.JKOMachines.Entities
{
    public class Whip
    {
        public int Id { get; set; }
        public string Marking { get; set; }
        public int Lenght { get; set; }
        public string Color { get; set; }
        public List<Beem> Beems { get; set; }

        public Whip()
        {
            Beems = new List<Beem>();
        }
    }
}
