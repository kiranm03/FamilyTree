using MeetTheFamily.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeetTheFamily.Test.Unit.Workers
{
    [TestClass]
    public class InputFileReaderTest
    {
        private InputFileReader _subject;

        [TestInitialize]
        public void SetUp()
        {
            _subject = new InputFileReader();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenFilePathIsEmpty()
        {
            //Arrange
            var fileName = string.Empty;
            //Act
            _subject.ReadFile(fileName);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ThrowExceptionWhenFilePathIsInvalid()
        {
            //Arrange
            var fileName = "@@##$$";
            //Act
            _subject.ReadFile(fileName);
            //Assert
        }

        [TestMethod]
        public void ParseFileWhenFilePathIsValid()
        {
            //Arrange            
            var fileName = "input.txt";
            //Act
            var output = _subject.ReadFile(fileName);
            //Assert
            Assert.IsNotNull(output);
        }
    }
}
