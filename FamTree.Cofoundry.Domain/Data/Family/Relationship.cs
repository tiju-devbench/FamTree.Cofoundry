using Cofoundry.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamTree.Cofoundry.Domain.Data.Family
{
    class Relationship
    {
         public int Person1Id { get; set; }
        public int Person2Id { get; set; }

        public virtual CustomEntity Person1 { get; set; }
        public virtual CustomEntity Person2 { get; set; }
        public RelationshipType Relation { get; set; }

        public DateTime CreateDate { get; set; }

        public enum RelationshipType
        {
            Father,
            Mother,
            Son,
            Daughter,
            Niece,
            Nephew,
            GrandFather,
            GrandMother
        }
    }
}
