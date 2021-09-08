using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10
{
    public class FindCountry
    {
        private string country;
        public FindCountry (string country)
        {
            this.country = country;
        }

        public bool FindCountryPredicate(Racer racer)
        {
            //指定一个协定，前置条件时racer并不为null，如果为null就引发异常
            Contract.Requires<ArgumentNullException>(racer != null);
            return racer.Country == country;
        }
    }
}
