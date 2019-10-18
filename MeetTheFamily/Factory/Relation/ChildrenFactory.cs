using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class ChildrenFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new Child();
        }
    }
}
