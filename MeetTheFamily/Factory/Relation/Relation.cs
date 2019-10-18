using MeetTheFamily.Model.Relation;
using System;
using System.Collections.Generic;

namespace MeetTheFamily.Factory.Relation
{
    public class Relation : IRelationFactory
    {
        private readonly Dictionary<Relations, RelationFactory> _factories;
        private static Relation _instance;

        private Relation()
        {
            _factories = new Dictionary<Relations, RelationFactory>();

            foreach (Relations action in Enum.GetValues(typeof(Relations)))
            {
                var factory = (RelationFactory)Activator.CreateInstance(Type.GetType($"MeetTheFamily.Factory.Relation.{Enum.GetName(typeof(Relations), action)}Factory, MeetTheFamily"));
                _factories.Add(action, factory);
            }
        }

        private static Relation Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Relation();
                }
                return _instance;
            }
        }

        public static Relation InitializeFactories()
        {
            return Instance;
        }

        public IRelation ExecuteCreation(Relations action)
        {
            return _factories[action].Create();
        }
    }
}
