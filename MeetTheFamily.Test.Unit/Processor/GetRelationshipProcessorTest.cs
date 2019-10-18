using MeetTheFamily.Factory.Relation;
using MeetTheFamily.Memory;
using MeetTheFamily.Model;
using MeetTheFamily.Model.Relation;
using MeetTheFamily.Processor;
using MeetTheFamily.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MeetTheFamily.Test.Unit.Processor
{
    [TestClass]
    public class GetRelationshipProcessorTest
    {
        private GetRelationshipProcessor _subject;
        private readonly Mock<IRelationWrapper> _relationWrapper = new Mock<IRelationWrapper>();
        private readonly Mock<IRelationFactory> _factory = new Mock<IRelationFactory>();
        private readonly Mock<IRelation> _relation = new Mock<IRelation>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionWhenInputIsNull()
        {
            //Arrange
            _subject = new GetRelationshipProcessor(null, _relationWrapper.Object);
            //Act
            _subject.Process();
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ThrowExceptionWhenRelationIsInvalid()
        {
            //Arrange
            var data = "Luna ABCD";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            //Act
            _subject.Process();
            //Assert
        }

        [TestMethod]
        public void ReturnPersonNotFoundMessageWhenPersonIsInvalid()
        {
            //Arrange
            var data = "Luna Siblings";
            var siblings = new string[] { Constants.MemberNotFound };
            
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.Siblings))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(siblings);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(Constants.MemberNotFound, output);
        }

        [TestMethod]
        public void ReturnAllValidSiblings()
        {
            //Arrange
            var data = "Luna Siblings";
            var siblings = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.Siblings))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(siblings);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidSon()
        {
            //Arrange
            var data = "Luna Son";
            var son = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.Son))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(son);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidDaughter()
        {
            //Arrange
            var data = "Luna Daughter";
            var daughter = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.Daughter))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(daughter);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidChildren()
        {
            //Arrange
            var data = "Luna Children";
            var children = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.Children))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(children);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidBrothers()
        {
            //Arrange
            var data = "Luna Brother";
            var brothers = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.Brother))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(brothers);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidSisters()
        {
            //Arrange
            var data = "Luna Sister";
            var sisters = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.Sister))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(sisters);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidBrotherInLaws()
        {
            //Arrange
            var data = "Luna Brother-In-Law";
            var brotherInLaws = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.BrotherInLaw))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(brotherInLaws);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidSisterInLaws()
        {
            //Arrange
            var data = "Luna sister-In-Law";
            var sisterInLaws = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.SisterInLaw))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(sisterInLaws);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidMaternalAunt()
        {
            //Arrange
            var data = "Luna maternal-Aunt";
            var maternalAunt = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.MaternalAunt))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(maternalAunt);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidPaternalAunt()
        {
            //Arrange
            var data = "Luna paternal-Aunt";
            var paternalAunt = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.PaternalAunt))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(paternalAunt);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidMaternalUncle()
        {
            //Arrange
            var data = "Luna Maternal-Uncle";
            var maternalUncle = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.MaternalUncle))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(maternalUncle);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void ReturnAllValidPaternalUncle()
        {
            //Arrange
            var data = "Luna Paternal-Uncle";
            var paternalUncle = new string[] { "Joe", "Karl", "Dave" };
            var expected = "Joe Karl Dave";
            _subject = new GetRelationshipProcessor(data, _relationWrapper.Object);
            _relationWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(Relations.PaternalUncle))
                .Returns(_relation.Object);
            _relation.Setup(r => r.Find(It.IsAny<string>()))
                .Returns(paternalUncle);
            //Act
            var output = _subject.Process();
            //Assert
            Assert.AreEqual(expected, output);
        }
    }
}
