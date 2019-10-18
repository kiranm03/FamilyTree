using MeetTheFamily.Model;
using MeetTheFamily.Model.Relation;
using MeetTheFamily.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetTheFamily.Test.Unit.Model.Relation
{
    [TestClass]
    public class BrotherTest
    {
        private Brother _subject;
        private readonly Mock<IRelationByGender> _sibling = new Mock<IRelationByGender>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new Brother(_sibling.Object);
        }

        [TestMethod]
        public void ReturnNoneMessageWhenThereIsNoBrother()
        {
            //Arrange
            var name = "Kiran";
            _sibling.Setup(c => c.FindByGender(It.IsAny<string>(), Gender.Male))
                .Returns(new string[] { Constants.MemberNotFound });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.MemberNotFound, output[0]);
        }

        [TestMethod]
        public void ReturnPersonWhenThereIsBrother()
        {
            //Arrange
            var name = "Kiran";
            var brotherName = "brother";
            _sibling.Setup(c => c.FindByGender(It.IsAny<string>(), Gender.Male))
                .Returns(new string[] { brotherName });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(brotherName, output[0]);
        }
    }
}
