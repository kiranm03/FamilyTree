using MeetTheFamily.Processor;

namespace MeetTheFamily.Factory
{
    public abstract class ProcessorFactory
    {
        public abstract IProcessor Create(string data); 
    }
}
