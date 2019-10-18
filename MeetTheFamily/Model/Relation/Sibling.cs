using MeetTheFamily.Memory;
using MeetTheFamily.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetTheFamily.Model.Relation
{
    public class Sibling : IRelation, IRelationByGender
    {
        private readonly IMemberCache _cache;

        public Sibling()
        {
            _cache = MemberCache.Instance;
        }
        public Sibling(IMemberCache memberCache)
        {
            _cache = memberCache;
        }

        public string[] Find(string name)
        {
            var motherName = _cache.Search(name)?.Mother;

            if (motherName == null)
                return new string[] { Constants.MemberNotFound };

            var children = _cache
                .Search(motherName)
                ?.Children;

            if (children.Count == 1 && children.First().Equals(name,StringComparison.OrdinalIgnoreCase))
                return new string[] { Constants.None };
            
            //remove searching person from the sibling list
            return children
                .Where(c => !c.Equals(name, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }
        public string[] FindByGender(string name, Gender gender)
        {
            var siblingName = Find(name);
            
            if (siblingName
                .Any(c => c.Equals(Constants.MemberNotFound) || c.Equals(Constants.None)))
                return siblingName;            

            var output = new List<string>();

            siblingName.ToList().ForEach(c => {
                if (gender == _cache.Search(c)?.Gender)
                    output.Add(c);
            });

            return output
                .ToArray();
        }
    }
}
