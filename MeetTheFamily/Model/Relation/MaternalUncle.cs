using MeetTheFamily.Memory;
using MeetTheFamily.Util;
using System.Collections.Generic;
using System.Linq;

namespace MeetTheFamily.Model.Relation
{
    /// <summary>
    /// Mothers brothers
    /// </summary>
    public class MaternalUncle : IRelation
    {
        private readonly IRelation _brother;
        private readonly IMemberCache _cache;

        public MaternalUncle(IRelation brother)
        {
            _brother = brother;
            _cache = MemberCache.Instance;
        }

        public MaternalUncle(IRelation brother, IMemberCache memberCache)
        {
            _brother = brother;
            _cache = memberCache;
        }

        public string[] Find(string name)
        {
            var output = new List<string>();

            var mother = _cache.Search(name)?.Mother;
            if (mother == null)
                return new string[] { Constants.MemberNotFound };

            return _brother.Find(mother);
        }
    }
}
