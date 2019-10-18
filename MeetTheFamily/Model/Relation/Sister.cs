namespace MeetTheFamily.Model.Relation
{
    public class Sister : IRelation
    {
        private readonly IRelationByGender _sibling;

        public Sister(IRelationByGender sibling)
        {
            _sibling = sibling;
        }

        public string[] Find(string name)
        {
            return _sibling
                .FindByGender(name, Gender.Female);
        }
    }
}
