namespace MeetTheFamily.Model.Relation
{
    public class Brother : IRelation
    {
        private readonly IRelationByGender _sibling;

        public Brother(IRelationByGender sibling)
        {
            _sibling = sibling;
        }
        public string[] Find(string name)
        {
            return _sibling
                .FindByGender(name, Gender.Male);
        }
    }
}
