using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo_checker
{
    class Model
    {
        private List<string> _repAddresses;

        public Model()
        {
            this._repAddresses = new List<string>();
        }

        public List<string> RepAddresses
        {
            get { return this._repAddresses; }
        }

        public bool CheckAddress(string address)
        {
            return this.RepAddresses.Contains(address);
        }

        public void AddAddress(string address)
        {
            this.RepAddresses.Add(address);
        }
    }
}
