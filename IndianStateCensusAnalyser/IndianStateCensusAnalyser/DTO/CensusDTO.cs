using IndianStateCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.DTO
{
    public class CensusDTO
    {
        /// <summary>
        /// Declaring private variables
        /// </summary>
        private string state;
        private long population;
        private long area;
        private long density;
        private int serialNumber;
        private string stateName;
        private int tin;
        private string stateCode;

        /// <summary>
        /// Creating CensusDTO constructor and passing CensusDataDAO as object.
        /// The data inside CensusDataDAO is state,population,area and density.
        /// So no need to pass the arguments as we are using CensusDataDAO object.
        /// </summary>
        /// <param name="censusDataDao"></param>
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }

        /// <summary>
        /// Creating CensusDTO constructor and passing StateCodeDAO as object.
        /// </summary>
        /// <param name="stateCodeDao"></param>
        public CensusDTO(StateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
    }
}