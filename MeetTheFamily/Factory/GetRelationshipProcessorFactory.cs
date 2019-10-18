using MeetTheFamily.Factory.Relation;
using MeetTheFamily.Processor;

namespace MeetTheFamily.Factory
{
    public class GetRelationshipProcessorFactory : ProcessorFactory
    {
        public override IProcessor Create(string data)
        {
            return new GetRelationshipProcessor(data, new RelationWrapper());
        }
    }
}
