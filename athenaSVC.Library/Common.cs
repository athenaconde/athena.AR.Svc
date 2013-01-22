using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using athena.AR.Data;

using athenaSVC.Library.Interface;

namespace athena.AR.SVC.Library
{
    public sealed  class Common //: ICommon
    {


        public static void Schedule()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Posts all sales to Account Receivables
        /// </summary>
        public static void PostAR()
        {
                 using (var dataManager = new Manager())
                {
                    dataManager.PostAR();
                }
         }

        /// <summary>
        /// Updates all AR with outstanding balances.
        /// </summary>
        /// <param name="datsToDue"></param>
        public static void UpdateAR(int datsToDue)
        {
            using (var dataManager = new Manager())
            {
                dataManager.UpdateAR(datsToDue);
            }
        }

       
    }
}
