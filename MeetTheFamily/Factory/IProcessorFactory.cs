using MeetTheFamily.Processor;


namespace MeetTheFamily.Factory
{
    public interface IProcessorFactory
    {
        IProcessor ExecuteCreation(ProcessorActions action, string data);
    }
}
