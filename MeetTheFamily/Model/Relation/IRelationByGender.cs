using System;
using System.Collections.Generic;
using System.Text;

namespace MeetTheFamily.Model.Relation
{
    public interface IRelationByGender
    {
        string[] FindByGender(string name, Gender gender);
    }
}
