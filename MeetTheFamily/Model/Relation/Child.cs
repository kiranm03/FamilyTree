using MeetTheFamily.Memory;
using MeetTheFamily.Util;
using System.Collections.Generic;
using System.Linq;

namespace MeetTheFamily.Model.Relation
{
    public class Child : IRelation, IRelationByGender
    {
        private readonly IMemberCache _cache;

        public Child()
        {
            _cache = MemberCache.Instance;
        }
        public Child(IMemberCache memberCache)
        {
            _cache = memberCache;
        }
        public string[] Find(string name)
        {
            var member = _cache.Search(name);

            if (member == null)
                return new string[] { Constants.MemberNotFound };

            var childrenName = member.Children;

            if (childrenName == null)
                return new string[] { Constants.None };

            return childrenName.ToArray();
        }
        public string[] FindByGender(string name, Gender gender)
        {
            var childrenName = Find(name);

            if (childrenName
                .Any(c => c.Equals(Constants.MemberNotFound) 
                    || c.Equals(Constants.None)))
                return childrenName;
            
            var output = new List<string>();

            childrenName.ToList().ForEach(c => {
                if (gender == _cache.Search(c)?.Gender)
                    output.Add(c);
            });

            return output
                .ToArray();
        }
    }
}
