using MeetTheFamily.Factory;
using MeetTheFamily.Processor;
using MeetTheFamily.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetTheFamily.Test.Unit.Workers
{
    [TestClass]
    public class InputFileProcessorTest
    {
        private InputFileProcessor _subject;
        private readonly Mock<IProcessorWrapper> _processorWrapper = new Mock<IProcessorWrapper>();
        private readonly Mock<IProcessorFactory> _factory = new Mock<IProcessorFactory>();
        private readonly Mock<IProcessor> _processor = new Mock<IProcessor>();

        [TestInitialize]
        public void SetUp()
        {
            _subject = new InputFileProcessor(_processorWrapper.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenInputIsNull()
        {
            //Arrange

            //Act
            _subject.Process(null);
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionWhenFileIsEmpty()
        {
            //Arrange
            var inputSteps = new string[] { };
            //Act
            _subject.Process(inputSteps);
            //Assert
            
        }

        [TestMethod]        
        public void InvokeAddChildProcessorForAddChildInstruction()
        {
            //Arrange
            var inputSteps = new string[] { "ADD_CHILD Luna Lola Female" };
            _processorWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(ProcessorActions.AddChild, It.IsAny<string>()))
                .Returns(_processor.Object);
            //Act
            _subject.Process(inputSteps);
            //Assert
            _processor.Verify(p => p.Process());
        }

        [TestMethod]
        public void InvokeGetRelationshipProcessorForGetRelationshipInstruction()
        {
            //Arrange
            var inputSteps = new string[] { "GET_RELATIONSHIP Lola Son" };
            _processorWrapper.Setup(p => p.InitializeFactories())
                .Returns(_factory.Object);
            _factory.Setup(f => f.ExecuteCreation(ProcessorActions.GetRelationship, It.IsAny<string>()))
                .Returns(_processor.Object);
            //Act
            _subject.Process(inputSteps);
            //Assert
            _processor.Verify(p => p.Process());
        }
    }
}
