using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class SiblingsFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new Sibling();
        }
    }
}
