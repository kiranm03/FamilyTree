using MeetTheFamily.Memory;
using MeetTheFamily.Model;
using MeetTheFamily.Model.Relation;
using MeetTheFamily.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeetTheFamily.Test.Unit.Model.Relation
{
    [TestClass]
    public class MaternalUncleTest
    {
        private MaternalUncle _subject;
        private readonly Mock<IRelation> _brother = new Mock<IRelation>();
        private readonly Mock<IMemberCache> _cache = new Mock<IMemberCache>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new MaternalUncle(_brother.Object, _cache.Object);
        }

        [TestMethod]
        public void FindMethodReturnPersonNotFoundMessageWhenNameNotExist()
        {
            //Arrange
            var name = "Kiran";
            _cache.Setup(c => c.Search(It.IsAny<string>()))
                .Returns((Member)null);

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.MemberNotFound, output[0]);
        }

        [TestMethod]
        public void FindMethodReturnNoneMessageWhenNoMaternalUncle()
        {
            //Arrange
            var name = "Kiran";
            var member = new Member(name, Gender.Male, "father", "mother");

            _cache.Setup(c => c.Search(It.IsAny<string>()))
                .Returns(member);
            _brother.Setup(s => s.Find(It.IsAny<string>()))
                .Returns(new string[] { Constants.None });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.None, output[0]);
        }

        [TestMethod]
        public void FindMethodReturnMaternalUncle()
        {
            //Arrange
            var name = "Kiran";
            var member = new Member(name, Gender.Male, "father", "mother");

            _cache.Setup(c => c.Search(name))
                .Returns(member);
            _brother.Setup(s => s.Find(member.Mother))
                .Returns(new string[] { "MaternalUncle" });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual("MaternalUncle", output[0]);
        }
    }
}
