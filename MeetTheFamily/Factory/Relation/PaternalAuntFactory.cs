using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class PaternalAuntFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new PaternalAunt(new BrotherFactory().Create());
        }
    }
}
