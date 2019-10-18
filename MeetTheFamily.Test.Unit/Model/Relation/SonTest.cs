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
    public class SonTest
    {
        private Son _subject;
        private readonly Mock<IRelationByGender> _child = new Mock<IRelationByGender>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new Son(_child.Object);
        }

        [TestMethod]
        public void ReturnNoneMessageWhenThereIsNoSon()
        {
            //Arrange
            var name = "Kiran";
            _child.Setup(c => c.FindByGender(It.IsAny<string>(), Gender.Male))
                .Returns(new string[] { Constants.None });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.None, output[0]);
        }

        [TestMethod]
        public void ReturnPersonWhenThereIsSon()
        {
            //Arrange
            var name = "Kiran";
            var sonName = "son";
            _child.Setup(c => c.FindByGender(It.IsAny<string>(), Gender.Male))
                .Returns(new string[] { sonName });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(sonName, output[0]);
        }
    }
}
