using MeetTheFamily.Memory;
using MeetTheFamily.Model;
using MeetTheFamily.Model.Relation;
using MeetTheFamily.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MeetTheFamily.Test.Unit.Model.Relation
{
    [TestClass]
    public class BrotherInLawTest
    {
        private BrotherInLaw _subject;
        private readonly Mock<IRelation> _brother = new Mock<IRelation>();
        private readonly Mock<IRelation> _sister = new Mock<IRelation>();
        private readonly Mock<IMemberCache> _cache = new Mock<IMemberCache>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new BrotherInLaw(_brother.Object, _sister.Object, _cache.Object);
        }

        [TestMethod]
        public void FindMethodReturnPersonNotFoundMessageWhenNameNotExist()
        {
            //Arrange
            var name = "Kiran";
            _cache.Setup(c => c.Search(It.IsAny<string>()))
                .Returns((Member)null);
            _sister.Setup(s=>s.Find(It.IsAny<string>()))
                .Returns(new string[] { Constants.MemberNotFound });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.MemberNotFound, output[0]);
        }

        [TestMethod]
        public void FindMethodReturnNoneMessageWhenNoBrotherInLaws()
        {
            //Arrange
            var name = "Kiran";
            var member = new Member(name, Gender.Male, "father", "mother");

            _cache.Setup(c => c.Search(It.IsAny<string>()))
                .Returns(member);
            _sister.Setup(s => s.Find(It.IsAny<string>()))
                .Returns(new string[] { Constants.None });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.None, output[0]);
        }

        [TestMethod]
        public void FindMethodReturnBrotherInLaws()
        {
            //Arrange
            var name = "Kiran";
            var sister = "Sister1";
            var member = new Member(name, Gender.Male, "father", "mother", "spouse");
            var broInlaw = new Member(sister, Gender.Female, "father", "mother", "BrotherInLaw2");

            _cache.Setup(c => c.Search(name))
                .Returns(member);
            _cache.Setup(c => c.Search(sister))
                .Returns(broInlaw);
            _sister.Setup(s => s.Find(It.IsAny<string>()))
                .Returns(new string[] { sister });
            _brother.Setup(s => s.Find(It.IsAny<string>()))
                .Returns(new string[] { "BrotherInLaw1" });

            //Act
            var output = _subject.Find(name);

            //Assert
            Assert.AreEqual(2, output.Length);
            Assert.AreEqual("BrotherInLaw1", output[0]);
            Assert.AreEqual("BrotherInLaw2", output[1]);
        }
    }
}
