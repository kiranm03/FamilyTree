using MeetTheFamily.Memory;
using MeetTheFamily.Model;
using MeetTheFamily.Model.Relation;
using MeetTheFamily.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetTheFamily.Test.Unit.Model.Relation
{
    [TestClass]
    public class SiblingTest
    {
        private Sibling _subject;
        private readonly Mock<IMemberCache> _cache = new Mock<IMemberCache>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new Sibling(_cache.Object);
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
        public void FindByGenderMethodReturnPersonNotFoundMessageWhenNameNotExist()
        {
            //Arrange
            var name = "Kiran";
            _cache.Setup(c => c.Search(It.IsAny<string>()))
                .Returns((Member)null);

            //Act
            var output = _subject.FindByGender(name, Gender.Male);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.MemberNotFound, output[0]);
        }

        [TestMethod]
        public void FindMethodReturnNoneMessageWhenNoSibling()
        {
            //Arrange
            var name = "Kiran";
            var mother = new Member(name, Gender.Female, "father", "mother","spouse", new List<string>() { "kid1" });
            var kid1 = new Member(mother.Children.First(), Gender.Male, "father", name);

            _cache.Setup(c => c.Search(name))
                .Returns(mother);
            _cache.Setup(c => c.Search(kid1.Name))
                .Returns(kid1);

            //Act
            var output = _subject.Find(kid1.Name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.None, output[0]);
        }

        [TestMethod]
        public void FindByGenderMethodReturnNoneMessageWhenNoSibling()
        {
            //Arrange
            var name = "Kiran";
            var mother = new Member(name, Gender.Female, "father", "mother", "spouse", new List<string>() { "kid1" });
            var kid1 = new Member(mother.Children.First(), Gender.Male, "father", name);

            _cache.Setup(c => c.Search(name))
                .Returns(mother);
            _cache.Setup(c => c.Search(kid1.Name))
                .Returns(kid1);

            //Act
            var output = _subject.FindByGender(kid1.Name, Gender.Male);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(Constants.None, output[0]);
        }

        [TestMethod]
        public void FindMethodReturnSibling()
        {
            //Arrange
            var name = "Kiran";
            var mother = new Member(name, Gender.Female, "father", "mother", "spouse", new List<string>() { "kid1", "kid2" });
            var kid1 = new Member(mother.Children.First(), Gender.Male, mother.Spouse, name);
            var kid2 = new Member(mother.Children.Last(), Gender.Male, mother.Spouse, name);

            _cache.Setup(c => c.Search(name))
               .Returns(mother);
            _cache.Setup(c => c.Search(kid1.Name))
                .Returns(kid1);

            //Act
            var output = _subject.Find(kid1.Name);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(kid2.Name, output[0]);
        }

        [TestMethod]
        public void FindByGenderMethodReturnFemaleChild()
        {
            //Arrange
            var name = "Kiran";
            var member = new Member(name, Gender.Female, "father", "mother", "spouse", new List<string>() { "kid1", "kid2" });
            var kid1 = new Member(member.Children.First(), Gender.Female, member.Spouse, member.Name);
            var kid2 = new Member(member.Children.Last(), Gender.Female, member.Spouse, member.Name);

            _cache.Setup(c => c.Search(name))
                .Returns(member);
            _cache.Setup(c => c.Search(kid1.Name))
                .Returns(kid1);
            _cache.Setup(c => c.Search(kid2.Name))
                .Returns(kid2);

            //Act
            var output = _subject.FindByGender(kid1.Name, Gender.Female);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(kid2.Name, output[0]);
        }

        [TestMethod]
        public void FindByGenderMethodReturnMaleChild()
        {
            //Arrange
            var name = "Kiran";
            var member = new Member(name, Gender.Female, "father", "mother", "spouse", new List<string>() { "kid1", "kid2" });
            var kid1 = new Member(member.Children.First(), Gender.Female, member.Spouse, member.Name);
            var kid2 = new Member(member.Children.Last(), Gender.Male, member.Spouse, member.Name);

            _cache.Setup(c => c.Search(name))
               .Returns(member);
            _cache.Setup(c => c.Search(kid1.Name))
                .Returns(kid1);
            _cache.Setup(c => c.Search(kid2.Name))
                .Returns(kid2);

            //Act
            var output = _subject.FindByGender(kid1.Name, Gender.Male);

            //Assert
            Assert.AreEqual(1, output.Length);
            Assert.AreEqual(kid2.Name, output[0]);
        }
    }
}
