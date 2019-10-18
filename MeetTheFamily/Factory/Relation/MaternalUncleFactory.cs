using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class MaternalUncleFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new MaternalUncle( new BrotherFactory().Create());
        }
    }
}
