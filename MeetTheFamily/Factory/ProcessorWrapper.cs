namespace MeetTheFamily.Factory
{
    public class ProcessorWrapper : IProcessorWrapper
    {
        public IProcessorFactory InitializeFactories()
        {
            return Processor.InitializeFactories();
        }
    }
}
