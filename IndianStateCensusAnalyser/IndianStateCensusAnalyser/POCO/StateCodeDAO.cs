using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        //Declaring variables.
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        /// <summary>
        /// Creating constructor of class CensusDataaDAO and passing serial Number, state Name, tin and state code.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="v4"></param>
        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            this.serialNumber = Convert.ToInt32(v1);
            this.stateName = v2;
            this.tin = Convert.ToInt32(v3);
            this.stateCode = v4;
        }
    }
}