namespace MeetTheFamily.Factory.Relation
{
    public class RelationWrapper : IRelationWrapper
    {
        IRelationFactory IRelationWrapper.InitializeFactories()
        {
            return Relation.InitializeFactories();
        }
    }
}
