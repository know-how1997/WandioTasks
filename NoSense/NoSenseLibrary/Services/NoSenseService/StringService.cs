using System;
using System.Collections.Generic;
using System.Linq;


namespace NoSenseLibrary.Services.NoSenseService
{
    public static class StringService
    {
        public static IEnumerable<int> GetIntArrayFromString(this string line, char separator = ',')
        {
            if (!line.Contains(separator))
                throw new Exception("String does not contain separator to be split");

            List<string> stringArray = line.Split(separator).ToList();

            List<string> trimmedStrings = new List<string>();

            foreach (var record in stringArray)
            {
                trimmedStrings.Add(record.Trim());
            }

            List<int> integerArray = new List<int>();

            Validate(trimmedStrings);

            foreach (var record in trimmedStrings)
            {
                integerArray.Add(Convert.ToInt32(record));
            }

            return integerArray;

        }
        private static void Validate(IEnumerable<string> strings)
        {
            foreach (var record in strings)
            {
                if (record == null)
                    throw new ArgumentNullException();

                ValidateNumber(record);
            }
        }
        private static void ValidateNumber(string record)
        {
            foreach (var character in record)
            {
                if (!char.IsNumber(character))
                    throw new Exception("Not a number");
            }
        }
    }
}
