using MeetTheFamily.Memory;
using MeetTheFamily.Util;
using System.Collections.Generic;
using System.Linq;

namespace MeetTheFamily.Model.Relation
{
    /// <summary>
    /// Mothers sisters
    /// </summary>
    public class MaternalAunt : IRelation
    {
        private readonly IRelation _sister;
        private readonly IMemberCache _cache;

        public MaternalAunt(IRelation sister)
        {
            _sister = sister;
            _cache = MemberCache.Instance;
        }

        public MaternalAunt(IRelation sister, IMemberCache memberCache)
        {
            _sister = sister;
            _cache = memberCache;
        }
        public string[] Find(string name)
        {
            var output = new List<string>();

            var mother = _cache.Search(name)?.Mother;
            if (mother == null)
                return new string[] { Constants.MemberNotFound };

            return _sister.Find(mother);       
        }
    }
}
