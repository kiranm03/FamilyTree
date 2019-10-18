namespace MeetTheFamily.Model.Relation
{
    public class Son : IRelation
    {
        private readonly IRelationByGender _child;

        public Son(IRelationByGender child)
        {
            _child = child;
        }
        public string[] Find(string name)
        {
            return _child
                .FindByGender(name, Gender.Male);
        }
    }
}
