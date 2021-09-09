using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap11.DataLib
{
    [Serializable]
    public class Team
    {
        public string Name { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public Team (string name ,params int[] years)
        {
            this.Name = name;
            this.Years = new List<int>(years);
        }
    }
}
