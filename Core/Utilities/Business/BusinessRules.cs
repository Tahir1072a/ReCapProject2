using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static bool Run(params bool[] logics)
        {
            foreach (var logic in logics)
            {
                if (logic)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
