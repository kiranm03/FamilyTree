using System;
using System.Collections.Generic;
using MeetTheFamily.Processor;

namespace MeetTheFamily.Factory
{
    public class Processor : IProcessorFactory
    {
        private readonly Dictionary<ProcessorActions, ProcessorFactory> _factories;
        private static Processor _instance;

        private Processor()
        {
            _factories = new Dictionary<ProcessorActions, ProcessorFactory>();

            foreach(ProcessorActions action in Enum.GetValues(typeof(ProcessorActions)))
            {
                var factory = (ProcessorFactory)Activator.CreateInstance(Type.GetType($"MeetTheFamily.Factory.{Enum.GetName(typeof(ProcessorActions), action)}ProcessorFactory, MeetTheFamily"));
                _factories.Add(action, factory);
            }
        }

        private static Processor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Processor();
                }
                return _instance;
            }
        }

        public static Processor InitializeFactories()
        {
            return Instance;
        }

        public IProcessor ExecuteCreation(ProcessorActions action, string data)
        {
            return _factories[action].Create(data);
        }
    }
}
