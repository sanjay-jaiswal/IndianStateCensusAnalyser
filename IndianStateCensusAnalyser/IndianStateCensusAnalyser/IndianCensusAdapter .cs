using IndianStateCensusAnalyser.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyser
{
    /// <summary>
    /// Inheriting the CensusAdapter class.
    /// </summary>
    class IndianCensusAdapter : CensusAdapter
    {
        // declaring array of string censusData.
        string[] censusData;

        //Creating an instance of dictionary as dataMap and passing CensusDTO. 
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Creating a dictionary and passing CensusDTO 
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File contains wrong delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);

                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new POCO.CensusDataDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new POCO.StateCodeDAO(column[0], column[1], column[2], column[3])));


            }

            return dataMap;
        }
    }
}
