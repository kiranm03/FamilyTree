using MeetTheFamily.Memory;
using MeetTheFamily.Model;
using MeetTheFamily.Processor;
using MeetTheFamily.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MeetTheFamily.Test.Unit.Processor
{
    [TestClass]
    public class AddChildProcessorTest
    {
        private AddChildProcessor _subject;
        private readonly Mock<IMemberCache> _cache = new Mock<IMemberCache>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenInputIsNull()
        {
            //Arrange
            _subject = new AddChildProcessor(null, _cache.Object);
            //Act
        }

        [TestMethod]
        public void ReturnMessageWhenMotherIsNotFound()
        {
            //Arrange
            _subject = new AddChildProcessor("Luna Lola Female", _cache.Object);
            _cache.Setup(c => c.Search(It.IsAny<string>()))
                .Returns((Member)null);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(Constants.MemberNotFound, output);
        }

        [TestMethod]
        public void AddChildFailsWhenMotherIsNotMarried()
        {
            //Arrange
            var mother = new Member("Luna", Gender.Female, "gdad", "gmom");
            //var father = new Member(mother.Spouse, Gender.Female, "gdad1", "gmom1", mother.Name);
            _subject = new AddChildProcessor("Luna Lola Female", _cache.Object);
            _cache.Setup(c => c.Search(mother.Name))
                .Returns(mother).Verifiable();
            //_cache.Setup(c => c.Search(mother.Spouse))
            //    .Returns(father).Verifiable();
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(Constants.ChildAdditionFail, output);
            _cache.VerifyAll();
        }

        [TestMethod]
        public void AddChildSuccess()
        {
            //Arrange
            var mother = new Member("Luna", Gender.Female, "gdad", "gmom", "spouse");
            var father = new Member(mother.Spouse, Gender.Female, "gdad1", "gmom1", mother.Name);
            _subject = new AddChildProcessor("Luna Lola Female", _cache.Object);
            _cache.Setup(c => c.Search(mother.Name))
                .Returns(mother).Verifiable();
            _cache.Setup(c => c.Search(mother.Spouse))
                .Returns(father).Verifiable();
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(Constants.ChildAdditionSuccess, output);
            _cache.VerifyAll();
        }
    }
}
