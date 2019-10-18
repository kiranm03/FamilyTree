using MeetTheFamily.Factory.Relation;
using MeetTheFamily.Model.Relation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetTheFamily.Processor
{
    public class GetRelationshipProcessor : IProcessor
    {
        private readonly string _data;
        private readonly IRelationWrapper _relationWrapper;
        private IRelationFactory _factory;

        public GetRelationshipProcessor(string data, IRelationWrapper relationWrapper)
        {            
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException(data);
            }
            _data = data;
            _relationWrapper = relationWrapper;
        }

        public string Process()
        {
            try
            {
                GetValuesFromData(out string name, out string relationText);

                var relation = (Relations)Enum.Parse(typeof(Relations), relationText, true);

                _factory = _relationWrapper.InitializeFactories();
                IRelation relationFinder;

                switch (relation)
                {
                    case Relations.Siblings:
                        relationFinder = _factory.ExecuteCreation(Relations.Siblings);
                        break;
                    case Relations.Son:
                        relationFinder = _factory.ExecuteCreation(Relations.Son);
                        break;
                    case Relations.Daughter:
                        relationFinder = _factory.ExecuteCreation(Relations.Daughter);
                        break;
                    case Relations.Children:
                        relationFinder = _factory.ExecuteCreation(Relations.Children);
                        break;
                    case Relations.Brother:
                        relationFinder = _factory.ExecuteCreation(Relations.Brother);
                        break;
                    case Relations.Sister:
                        relationFinder = _factory.ExecuteCreation(Relations.Sister);
                        break;
                    case Relations.BrotherInLaw:
                        relationFinder = _factory.ExecuteCreation(Relations.BrotherInLaw);
                        break;
                    case Relations.SisterInLaw:
                        relationFinder = _factory.ExecuteCreation(Relations.SisterInLaw);
                        break;
                    case Relations.MaternalAunt:
                        relationFinder = _factory.ExecuteCreation(Relations.MaternalAunt);
                        break;
                    case Relations.PaternalAunt:
                        relationFinder = _factory.ExecuteCreation(Relations.PaternalAunt);
                        break;
                    case Relations.MaternalUncle:
                        relationFinder = _factory.ExecuteCreation(Relations.MaternalUncle);
                        break;
                    case Relations.PaternalUncle:
                        relationFinder = _factory.ExecuteCreation(Relations.PaternalUncle);
                        break;
                    default:
                        throw new ArgumentException();
                }

                return relationFinder.Find(name)?.Aggregate((a, b) => $"{a} {b}");
            }
            catch(Exception ex)
            {
                throw new Exception($"Cannot find Relation: {ex.Message}");
            }
        }

        private void GetValuesFromData(out string name, out string relationText)
        {
            name = _data.Split(' ').First();

            relationText = _data
                .Replace(name, string.Empty)
                .Replace("-", string.Empty)
                .Trim();
        }
    }
}
