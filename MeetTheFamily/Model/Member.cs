using System;
using System.Collections.Generic;
using System.Text;

namespace MeetTheFamily.Model
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Member
    {
        private readonly string _name;
        private readonly Gender _gender;
        private readonly string _father;
        private readonly string _mother;
        private readonly string _spouse;
        private List<string> _children;

        public Member(string name, Gender gender, string father, string mother, string spouse = null, List<string> children = null)
        {
            ValidateMemberName(name);

            this._name = name;
            this._gender = gender;
            this._father = father;
            this._mother = mother;
            this._spouse = spouse;
            this._children = children;
        }

        public Gender Gender { get { return _gender; } }
        public string Name { get { return _name; } }
        public string Father { get { return _father; } }
        public string Mother { get { return _mother; } }
        public string Spouse { get { return _spouse; } }
        public List<string> Children { get { return _children; } }

        private void ValidateMemberName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(name);
            }
        }

        public void AddChild(string children)
        {
            if (_children is null)
                _children = new List<string>();
            _children.Add(children);
        }

        //private readonly string _name;
        //private readonly Gender _gender;
        //private readonly Member _father;
        //private readonly Member _mother;
        //private readonly Member _spouse;
        //private readonly List<Member> _children;

        //public Gender Gender { get { return _gender; } }
        //public string Name { get { return _name; } }

        //private Member() { }

        //public Member(string name, Gender gender) : this(name, gender, null, null, null, null) { }
        //public Member(string name, Gender gender, Member father, Member mother) : this(name, gender, father, mother, null, null) { }
        //public Member(string name, Gender gender, Member father, Member mother, Member spouse) : this(name, gender, father, mother, spouse, null) { }

        //public Member(string name, Gender gender, Member father, Member mother, Member spouse, List<Member> children)
        //{
        //    ValidateData(name, gender, father, mother, spouse, children);

        //    this._name = name;
        //    this._gender = gender;
        //    this._father = father;
        //    this._mother = mother;
        //    this._children = children;
        //}

        //private void ValidateData(string name, Gender gender, Member father, Member mother, Member spouse, List<Member> children)
        //{
        //    if(string.IsNullOrEmpty(name))
        //    {
        //        throw new ArgumentNullException(name);
        //    }

        //    if ((mother != null && father != null) && mother == father)
        //    {
        //        throw new ArgumentException($"mother and father cannnot be the same: {father}, {mother}");
        //    }

        //    if ((father != null) && father.Gender != Gender.Male)
        //    {
        //        throw new ArgumentException($"father should be male: {father}");
        //    }

        //    if ((mother != null) && mother.Gender != Gender.Female)
        //    {
        //        throw new ArgumentException($"mother should be female: {mother}");
        //    }

        //}
    }
}
