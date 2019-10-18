using MeetTheFamily.Processor;

namespace MeetTheFamily.Factory
{
    public class AddChildProcessorFactory : ProcessorFactory
    {
        public override IProcessor Create(string data)
        {
            return new AddChildProcessor(data);
        }
    }
}
