
using MeetTheFamily.Memory;
using MeetTheFamily.Util;
using System.Collections.Generic;
using System.Linq;

namespace MeetTheFamily.Model.Relation
{
    /// <summary>
    /// Fathers sisters
    /// </summary>
    public class PaternalAunt : IRelation
    {
        private readonly IRelation _sister;
        private readonly IMemberCache _cache;

        public PaternalAunt(IRelation sister)
        {
            _sister = sister;
            _cache = MemberCache.Instance;
        }

        public PaternalAunt(IRelation sister, IMemberCache memberCache)
        {
            _sister = sister;
            _cache = memberCache;
        }

        public string[] Find(string name)
        {
            var output = new List<string>();

            var father = _cache.Search(name)?.Father;
            if (father == null)
                return new string[] { Constants.MemberNotFound };

            return _sister.Find(father);
        }
    }
}
