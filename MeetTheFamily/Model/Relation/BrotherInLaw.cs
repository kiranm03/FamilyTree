using MeetTheFamily.Memory;
using MeetTheFamily.Util;
using System.Collections.Generic;
using System.Linq;

namespace MeetTheFamily.Model.Relation
{
    public class BrotherInLaw : IRelation
    {
        private readonly IRelation _brother;
        private readonly IRelation _sister;
        private readonly IMemberCache _cache;

        public BrotherInLaw(IRelation brother, IRelation sister)
        {
            _brother = brother;
            _sister = sister;
            _cache = MemberCache.Instance;
        }

        public BrotherInLaw(IRelation brother, IRelation sister, IMemberCache memberCache)
        {
            _brother = brother;
            _sister = sister;
            _cache = memberCache;
        }

        public string[] Find(string name)
        {
            var output = new List<string>();
            //Find spouse's brothers
            var spouse = _cache.Search(name)?.Spouse;

            if (spouse != null)
            {
                var brothers = _brother.Find(spouse)?.ToList();
                if (brothers != null)
                    output.AddRange(brothers);
            }
            //Find husbands of siblings
            var sisters = _sister.Find(name);

            if (sisters.Any(c => c.Equals(Constants.MemberNotFound) || c.Equals(Constants.None)))
            {
                if (!output.Any())
                    output.AddRange(sisters);
                return output.ToArray();
            }

            foreach (var sis in sisters)
            {
                var sp = _cache.Search(sis)?.Spouse;
                if (sp != null)
                    output.Add(sp);
            }

            return output.ToArray();
        }
    }
}
