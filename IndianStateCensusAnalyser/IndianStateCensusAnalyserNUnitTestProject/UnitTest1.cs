using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserNUnitTestProject
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.csv";

        static string wrongHeaderIndianCensusFile = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\WrongHeaderIndiaStateCensusData.csv";
        static string IncorrectIndianStateCensusFileName = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData1.csv";

        static string wrongIndianStateCensusFileType = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.txt";      
        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\DelimiterIndiaStateCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 1.1 : Should return total number of records.
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);

        }

        /// <summary>
        /// TC 1.2 : Should return File not found.
        /// </summary>
        [Test]
        public void GivenIncorrectIndianCensusDataFileName_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IncorrectIndianStateCensusFileName, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// TC 1.3 : Given CorrectIndian Census Data File Name But Invalid Extension Should return Invalud file type.
        /// </summary>
        [Test]
        public void GivenCorrectIndianCensusDataFileName_ButInvalidExtension_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// TC 1.4 : Given Delimiter Inorrect Indian Census Data File should return Incorrect delemeter.
        /// </summary>
        [Test]
        public void GivenDelimiterInorrectIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// //TC1.5 Given Wrong Header Indian State Census Data When Read Should Return Incorrect header.
        /// </summary>
        [Test]
        public void GivenWrongHeaderIndianStateCensusData_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFile, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}