using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class SisterInLawFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new SisterInLaw(new BrotherFactory().Create(),
                new SisterFactory().Create());
        }
    }
}
