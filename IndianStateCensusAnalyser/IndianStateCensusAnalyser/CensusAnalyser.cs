using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        /// <summary>
        /// Declaring ENUM.
        /// </summary>
        public enum Country
        {
            INDIA, US, BRAZIL
        }

        /// <summary>
        /// Passing CesusDTO as object.
        /// Creating instance of Dictionary to store CesusDTO data like state, population, area, density.
        /// </summary>
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
