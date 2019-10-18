using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeetTheFamily.Workers
{
    public class InputFileReader
    {
        public string[] ReadFile(string inputFilePath)
        {
            if (string.IsNullOrEmpty(inputFilePath))
                throw new ArgumentNullException("File path should not be empty", inputFilePath);

            try
            {
                var fileSteps = File.ReadAllLines(@inputFilePath);
                return fileSteps;
            }
            catch(Exception ex)
            {
                throw new Exception($"Something went wrong while reading the file: {ex.Message}");
            }
        }
    }
}
