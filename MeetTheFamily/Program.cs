using MeetTheFamily.Factory;
using MeetTheFamily.Memory;
using MeetTheFamily.Model;
using MeetTheFamily.Workers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetTheFamily
{
    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                InputFileReader inputFileReader = new InputFileReader();

                Console.WriteLine("Enter the file path");
                var inputFilePath = Console.ReadLine();
                var inputFileSteps = inputFileReader.ReadFile(inputFilePath);

                SeedData();

                InputFileProcessor inputFileProcessor = new InputFileProcessor(new ProcessorWrapper());
                inputFileProcessor.Process(inputFileSteps);
                
                Console.ReadKey();
            }
            catch(Exception ex)
            {                
                Console.WriteLine($"Something unexpected has happened: {ex.Message}");
                Console.ReadKey();
            }

        }

        private static void SeedData()
        {
            AddFamilyMember("King Arthur", Gender.Male, null, null, "Queen Margret", new List<string>() {"Bill","Charlie", "Percy","Ronald", "Ginerva" });
            AddFamilyMember("Queen Margret", Gender.Female, null, null, "King Arthur", new List<string>() { "Bill", "Charlie", "Percy", "Ronald", "Ginerva" });
            AddFamilyMember("Charlie", Gender.Male, "King Arthur", "Queen Margret");
            AddFamilyMember("Bill", Gender.Male, "King Arthur", "Queen Margret", "Flora", new List<string>() { "Victoire", "Dominique", "Louis" });
            AddFamilyMember("Flora", Gender.Female, null, null, "Bill", new List<string>() { "Victoire", "Dominique", "Louis" });
            AddFamilyMember("Percy", Gender.Male, "King Arthur", "Queen Margret", "Audrey", new List<string>() { "Molly", "Lucy"});
            AddFamilyMember("Audrey", Gender.Female, null, null, "Percy", new List<string>() { "Molly", "Lucy" });
            AddFamilyMember("Ronald", Gender.Male, "King Arthur", "Queen Margret", "Helen", new List<string>() { "Rose", "Hugo" });
            AddFamilyMember("Helen", Gender.Female, null, null, "Ronald", new List<string>() { "Rose", "Hugo" });
            AddFamilyMember("Ginerva", Gender.Female, "King Arthur", "Queen Margret", "Harry", new List<string>() { "James", "Albus","Lily" });
            AddFamilyMember("Harry", Gender.Male, null, null, "Ginerva", new List<string>() { "James", "Albus", "Lily" });
            AddFamilyMember("Victoire", Gender.Female, "Charlie", "Flora", "Ted", new List<string>() { "Remus" });
            AddFamilyMember("Ted", Gender.Male, null, null, "Victoire", new List<string>() { "Remus" });
            AddFamilyMember("Dominique", Gender.Female, "Charlie", "Flora");
            AddFamilyMember("Louis", Gender.Male, "Charlie", "Flora");
            AddFamilyMember("Remus", Gender.Male, "Ted", "Victoire");
            AddFamilyMember("Molly", Gender.Female, "Percy", "Audrey");
            AddFamilyMember("Lucy", Gender.Female, "Percy", "Audrey");
            AddFamilyMember("Rose", Gender.Female, "Ronald", "Helen", "Malfoy", new List<string>() { "Draco","Aster" });
            AddFamilyMember("Malfoy", Gender.Male, null, null, "Rose", new List<string>() { "Draco", "Aster" });
            AddFamilyMember("Hugo", Gender.Male, "Ronald", "Helen");
            AddFamilyMember("Draco", Gender.Male, "Malfoy", "Rose");
            AddFamilyMember("Aster", Gender.Female, "Malfoy", "Rose");
            AddFamilyMember("James", Gender.Male, "Harry", "Ginerva", "Darcy", new List<string>() { "William"});
            AddFamilyMember("Darcy", Gender.Female, null, null, "James", new List<string>() { "William" });
            AddFamilyMember("William", Gender.Male, "James", "Darcy");
            AddFamilyMember("Albus", Gender.Male, "Harry", "Ginerva", "Alice", new List<string>() { "Ron","Ginny" });
            AddFamilyMember("Alice", Gender.Female, null, null, "Albus", new List<string>() { "Ron", "Ginny" });
            AddFamilyMember("Ron", Gender.Male, "Albus", "Alice");
            AddFamilyMember("Ginny", Gender.Female, "Albus", "Alice");
            AddFamilyMember("Lily", Gender.Female, "Harry", "Ginerva");
        }

        private static void AddFamilyMember(string name, Gender gender, string father, string mother, string spouse = null, List<string> children = null)
        {
            MemberCache
                .Instance
                .AddOrUpdateMember(new Member(name, gender, father, mother, spouse, children));
        }
    }
}