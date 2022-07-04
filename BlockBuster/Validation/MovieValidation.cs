using BlockBuster.Entity;
using BlockBuster.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.Validation
{
    public class MovieValidation
    {
        private int _checkInt;
        public bool CheckInt(string _checkInt)
        {          
            if (!int.TryParse(_checkInt, out this._checkInt))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int _convertInt;
        public int ConvertInt(string _convertInt)
        {
            int.TryParse(_convertInt, out this._convertInt);
            return this._convertInt;
        }
        
    }
}
