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
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFile = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\WrongHeaderIndiaStateCensusData.csv";

        static string IncorrectIndianStateCensusFileName = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData1.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCensusData.txt";

        static string wrongDelimiterIndianCensusFilePath = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\DelimiterIndiaStateCensusData.csv";


        static string indiaStateCodeFilePath = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCode.csv";

        static string wrongHeaderIndiaStateCodeFile = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\WrongHeaderIndiaStateCode.csv";
        static string IncorrectIndiaStateCodeFileName = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCode1.csv";

        static string wrongIndianStateCodeFileType = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\IndiaStateCode.txt";
        static string wrongDelimiterIndiaStateCodeFilePath = @"C:\Users\HP\Desktop\SanjuBridgelabz\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndianStateCensusAnalyserNUnitTestProject\CSVFolder\DelimiterIndiaStateCode.csv";

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


        /// <summary>
        /// TC2.1 Given Indian State Code File Data Should Return total records.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeFileData_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indiaStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(2, totalRecord.Count);

        }

        /// <summary>
        /// TC2.2 Given Incorrect India State Code File Name Should Return file not found.
        /// </summary>
        [Test]
        public void GivenIncorrectIndiaStateCodeFileName_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IncorrectIndiaStateCodeFileName, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// TC2.3 Given Correct Indian State Code File Name But Extension Incorrect should return Invalid file type.
        /// </summary>
        [Test]
        public void GivenCorrectIndianStateCodeFileName_But_Extension_Incorrect_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// TC2.4 Given Delimiter Inorrect India State Code File Should Return Incorrect delimeter.
        /// </summary>
        [Test]
        public void GivenDelimiterInorrectIndiaStateCodeFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndiaStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// TC2.5 Given Wrong Header Indian State Code Should Return Incorrect header.
        /// </summary>
        [Test]
        public void GivenWrongHeaderIndianStateCode_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndiaStateCodeFile, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

    }
}