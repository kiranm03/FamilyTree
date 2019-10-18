using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public interface IRelationFactory
    {
        IRelation ExecuteCreation(Relations action);
    }
}
