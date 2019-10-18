using MeetTheFamily.Memory;
using MeetTheFamily.Model;
using MeetTheFamily.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetTheFamily.Processor
{
    public class AddChildProcessor : IProcessor
    {
        private readonly string _data;
        private readonly IMemberCache _cache;
        
        public AddChildProcessor(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(data);
            }
            _data = data;
            _cache = MemberCache.Instance;
        }

        public AddChildProcessor(string data, IMemberCache memberCache)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(data);
            }
            _data = data;
            _cache = memberCache;
        }

        public string Process()
        {
            try
            {
                GetValuesFromData(out string motherName, out string name, out Gender gender);

                var mother = _cache
                    .Search(motherName);

                if (mother == null)
                    return Constants.MemberNotFound;

                if (mother.Spouse == null)
                    return Constants.ChildAdditionFail;

                mother.AddChild(name);

                var child = new Member(name, gender, mother.Spouse, mother.Name);

                //Add new Child member
                _cache.AddOrUpdateMember(child);

                //update mother
                _cache.AddOrUpdateMember(mother);

                //update father
                var father = _cache.Search(mother.Spouse);

                father.AddChild(name);
                _cache.AddOrUpdateMember(father);

                return Constants.ChildAdditionSuccess;
            }
            catch(Exception)
            {
                return Constants.ChildAdditionFail;
            }

        }

        private void GetValuesFromData(out string motherName, out string name, out Gender gender)
        {
            var dataCollection = _data.Split(' ');

            motherName = dataCollection
                .First();
            name = dataCollection
                .Skip(1)
                .First();

            var genderString = dataCollection
                .Last()
                .ToUpperInvariant();

            gender = genderString.Equals("MALE", StringComparison.OrdinalIgnoreCase) ? Gender.Male : Gender.Female;
        }
    }
}
