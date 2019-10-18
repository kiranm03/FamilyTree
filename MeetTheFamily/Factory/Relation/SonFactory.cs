using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class SonFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new Son(new Child());
        }
    }
}
