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
    public class DaughterTest
    {
        private Daughter _subject;
        private readonly Mock<IRelationByGender> _child = new Mock<IRelationByGender>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new Daughter(_child.Object);
        }

        [TestMethod]
        public void ReturnNoneMessageWhenThereIsNoDaughter()
        {
            //Arrange
            var name = "Kiran";
            _child.Setup(c => c.FindByGender(It.IsAny<string>(), Gender.Female))
                .Returns(new string[] { Constants.None });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.None, output[0]);
        }

        [TestMethod]
        public void ReturnPersonWhenThereIsDaughter()
        {
            //Arrange
            var name = "Kiran";
            var daughterName = "daughter";
            _child.Setup(c => c.FindByGender(It.IsAny<string>(), Gender.Female))
                .Returns(new string[] { daughterName });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(daughterName, output[0]);
        }
    }
}
