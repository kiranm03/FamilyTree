using System.Collections.Generic;
using MeetTheFamily.Memory;
using System.Linq;
using MeetTheFamily.Util;

namespace MeetTheFamily.Model.Relation
{
    /// <summary>
    /// Fathers brothers
    /// </summary>
    public class PaternalUncle : IRelation
    {
        private readonly IRelation _brother;
        private readonly IMemberCache _cache;

        public PaternalUncle(IRelation brother)
        {
            _brother = brother;
            _cache = MemberCache.Instance;
        }
        public PaternalUncle(IRelation brother, IMemberCache memberCache)
        {
            _brother = brother;
            _cache = memberCache;
        }

        public string[] Find(string name)
        {
            var output = new List<string>();

            var father = _cache.Search(name)?.Father;
            if (father == null)
                return new string[] { Constants.MemberNotFound };

            return _brother.Find(father);            
        }
    }
}
