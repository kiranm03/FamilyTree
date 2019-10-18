using MeetTheFamily.Memory;
using MeetTheFamily.Util;
using System.Collections.Generic;
using System.Linq;

namespace MeetTheFamily.Model.Relation
{
    public class SisterInLaw : IRelation
    {
        private readonly IRelation _brother;
        private readonly IRelation _sister;
        private readonly IMemberCache _cache;

        public SisterInLaw(IRelation brother, IRelation sister)
        {
            _brother = brother;
            _sister = sister;
            _cache = MemberCache.Instance;
        }

        public SisterInLaw(IRelation brother, IRelation sister, IMemberCache memberCache)
        {
            _brother = brother;
            _sister = sister;
            _cache = memberCache;
        }

        public string[] Find(string name)
        {
            var output = new List<string>();
            //Find spouse's sisters
            var spouse = _cache.Search(name)?.Spouse;

            if (spouse != null)
            {
                var sisters = _sister.Find(spouse)?.ToList();
                if (sisters != null)
                    output.AddRange(sisters);
            }
            //Find wives of siblings
            var brothers = _brother.Find(name);

            if (brothers.Any(c => c.Equals(Constants.MemberNotFound) || c.Equals(Constants.None)))
            {
                if (!output.Any())
                    output.AddRange(brothers);
                return output.ToArray();
            }
            
            foreach (var bro in brothers)
            {
                var sp = _cache.Search(bro)?.Spouse;
                if (sp != null)
                    output.Add(sp);
            }

            return output.ToArray();
        }
    }
}
