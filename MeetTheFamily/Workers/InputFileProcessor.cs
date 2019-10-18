using MeetTheFamily.Util;
using System;
using System.Linq;
using MeetTheFamily.Processor;
using MeetTheFamily.Factory;

namespace MeetTheFamily.Workers
{
    public class InputFileProcessor
    {
        private readonly IProcessorWrapper _processorWrapper;
        private IProcessorFactory _factory;

        public InputFileProcessor(IProcessorWrapper processorWrapper)
        {
            _processorWrapper = processorWrapper;
        }
                
        public void Process(string[] inputFileSteps)
        {
            if (!inputFileSteps.Any())
            {
                throw new ArgumentException($"Steps are empty in the file: {inputFileSteps}");
            }

            _factory = _processorWrapper.InitializeFactories();
            foreach (var i in inputFileSteps)
                ProcessInstruction(i);
        }

        private void ProcessInstruction(string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
            {
                throw new ArgumentNullException(inputData);
            }

            inputData = inputData
                            .Trim();
                        
            SplitInstructionAndData(inputData, out string instruction, out string data);

            Processor.IProcessor processor;

            switch (instruction.ToUpperInvariant())
            {
                case Constants.AddChildInstruction:
                    processor = _factory
                        .ExecuteCreation(ProcessorActions.AddChild, data);
                    break;

                case Constants.GetRelationshipInstruction:
                    processor = _factory
                        .ExecuteCreation(ProcessorActions.GetRelationship, data);
                    break;

                default:
                    processor = null;
                    Console.WriteLine(Constants.InvalidInput);
                    return;
            }

            Console.WriteLine(processor.Process());
        }

        private void SplitInstructionAndData(string inputData, out string instruction, out string data)
        {
            instruction = inputData
                .Split(' ')
                .First();

            data = inputData
                .Replace(instruction, string.Empty)
                .Trim();
        }        
    }
}
