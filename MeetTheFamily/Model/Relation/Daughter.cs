namespace MeetTheFamily.Model.Relation
{
    public class Daughter : IRelation
    {
        private readonly IRelationByGender _child;

        public Daughter(IRelationByGender child)
        {
            _child = child;
        }
        public string[] Find(string name)
        {
            return _child
                .FindByGender(name, Gender.Female);
        }
    }
}
