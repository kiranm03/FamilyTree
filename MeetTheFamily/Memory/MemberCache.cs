using MeetTheFamily.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetTheFamily.Memory
{
    public sealed class MemberCache : IMemberCache
    {
        private static Dictionary<string,Member> _cache;
        private static MemberCache _instance;

        private MemberCache()
        {
            _cache = new Dictionary<string, Member>();
        }

        public static MemberCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MemberCache();
                }
                return _instance;
            }
        }

        public void AddOrUpdateMember(Member member)
        {
            if (_cache.ContainsKey(member.Name))
            {
                _cache.Remove(member.Name);
                _cache.Add(member.Name, member);
            }
            else
            _cache.Add(member.Name,member);
        }

        public Member Search(string name)
        {
            _cache.TryGetValue(name, out Member output);
            return output;
        }        
    }
}
