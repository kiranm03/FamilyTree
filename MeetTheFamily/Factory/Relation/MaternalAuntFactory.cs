using System;
using System.Collections.Generic;
using System.Text;
using MeetTheFamily.Model.Relation;

namespace MeetTheFamily.Factory.Relation
{
    public class MaternalAuntFactory : RelationFactory
    {
        public override IRelation Create()
        {
            return new MaternalAunt(new BrotherFactory().Create());
        }
    }
}
