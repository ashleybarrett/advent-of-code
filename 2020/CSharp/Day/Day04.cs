using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day04 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            var input = await FileInputHelper.GetInput("Input/day-04.txt");
            return GetNumberOfValidPassports(input, IsValidPassportForPartOne);
        }

        public async Task<long> SolvePartTwo()
        {
            var input = await FileInputHelper.GetInput("Input/day-04.txt");
            return GetNumberOfValidPassports(input, IsValidPassportForPartTwo);
        }

        private long GetNumberOfValidPassports(string[] input, Func<Dictionary<string, string>, bool> validationFunc)
        {
            var inputLength = input.Length;

            var passportFields = new Dictionary<string, string>();

            var numberOfValidPassports = 0;

            for (int i = 0; i <= inputLength; i++)
            {
                if(i == inputLength || string.IsNullOrWhiteSpace(input[i]))
                {
                    if(validationFunc(passportFields))
                    {
                        numberOfValidPassports++;
                    }

                    passportFields = new Dictionary<string, string>();
                }
                else
                {
                    var fields = input[i].Split(' ').ToDictionary(x => x[0..3], x => x[4..]);
                    
                    foreach(var field in fields)
                    {
                        passportFields.Add(field.Key, field.Value);
                    }
                }
            }

            return numberOfValidPassports;
        }

        private bool IsValidPassportForPartOne(Dictionary<string, string> passportFields)
            => passportFields.Count == 8 || (passportFields.Count == 7 && !passportFields.ContainsKey("cid"));

        private bool IsValidPassportForPartTwo(Dictionary<string, string> passportFields)
        {
            var rules = new List<Func<Dictionary<string, string>, bool>>
            {
                (p) => p.TryGetValue("byr", out var birthYear) && ValidRange(birthYear, 1920, 2002),
                (p) => p.TryGetValue("iyr", out var issueYear) && ValidRange(issueYear, 2010, 2020),
                (p) => p.TryGetValue("eyr", out var expirationYear) && ValidRange(expirationYear, 2020, 2030),
                (p) => 
                {
                    if(!passportFields.TryGetValue("hgt", out var height))
                    {
                        return false;
                    }
                    else if(height.EndsWith("cm"))
                    {
                        return ValidRange(height.Replace("cm", ""), 150, 193);
                    }
                    else if(height.EndsWith("in"))
                    {
                        return ValidRange(height.Replace("in", ""), 59, 76);
                    }

                    return false;
                },
                (p) => p.TryGetValue("hcl", out var hairColour) && Regex.IsMatch(hairColour, "[#]{1}[0-9a-f]{6}"),
                (p) => p.TryGetValue("ecl", out var eyeColour) && new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(eyeColour),
                (p) => p.TryGetValue("pid", out var passportId) && passportId.Length == 9
            };

            return rules.All(r => r(passportFields));
        }

        private bool ValidRange(string value, int min, int max)
            => int.TryParse(value, out int intValue) && intValue >= min && intValue <= max;
    }
}