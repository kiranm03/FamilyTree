using MeetTheFamily.Model;
using MeetTheFamily.Model.Relation;
using MeetTheFamily.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeetTheFamily.Test.Unit.Model.Relation
{
    [TestClass]
    public class SisterTest
    {
        private Sister _subject;
        private readonly Mock<IRelationByGender> _child = new Mock<IRelationByGender>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new Sister(_child.Object);
        }

        [TestMethod]
        public void ReturnNoneMessageWhenThereIsNoSister()
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
        public void ReturnPersonWhenThereIsSister()
        {
            //Arrange
            var name = "Kiran";
            var sisterName = "Sister";
            _child.Setup(c => c.FindByGender(It.IsAny<string>(), Gender.Female))
                .Returns(new string[] { sisterName });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(sisterName, output[0]);
        }
    }
}
