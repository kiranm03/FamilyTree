using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class DaughterFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new Daughter(new Child());
        }
    }
}
