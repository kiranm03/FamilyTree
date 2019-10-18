using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class PaternalUncleFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new PaternalUncle(new BrotherFactory().Create());
        }
    }
}
