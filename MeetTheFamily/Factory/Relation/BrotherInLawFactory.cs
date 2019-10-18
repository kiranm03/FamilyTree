using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class BrotherInLawFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new BrotherInLaw(new BrotherFactory().Create(),
                new SisterFactory().Create());
        }
    }
}
