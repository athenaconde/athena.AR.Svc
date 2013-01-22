using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace athenaSVC.Library.Interface
{
    interface ICommon
    {
         void Schedule();
         void PostAR();
         void UpdateAR(int daysTodue);
    }
}
