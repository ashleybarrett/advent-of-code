using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Day
{
    public class Day02 : IDayPuzzle
    {
        public async Task<long> SolvePartOne()
        {
            var input = await FileInputHelper.GetInput("Input/day-02.txt");

            var passwordPolicies = PassInputToPasswordPolicies(input);

            var result = passwordPolicies.Count(IsPart1PasswordPolicy);

            return result;
        }

        public async Task<long> SolvePartTwo()
        {
            var input = await FileInputHelper.GetInput("Input/day-02.txt");

            var passwordPolicies = PassInputToPasswordPolicies(input);

            var result = passwordPolicies.Count(IsPart2PasswordPolicy);

            return result;
        }

        private bool IsPart1PasswordPolicy(PasswordPolicy passwordPolicy)
        {
            var occurances = passwordPolicy.Password.Count(c => c == passwordPolicy.Letter);

            return occurances <= passwordPolicy.HighNumber && occurances >= passwordPolicy.LowNumber;
        }

        private bool IsPart2PasswordPolicy(PasswordPolicy passwordPolicy)
        {
            var letters = new char[] 
            { 
                passwordPolicy.Password[passwordPolicy.LowNumber - 1], 
                passwordPolicy.Password[passwordPolicy.HighNumber - 1] 
            };    
            
            return letters.Count(c => c == passwordPolicy.Letter) == 1;
        }

        private List<PasswordPolicy> PassInputToPasswordPolicies(string[] input)
            => input.Select(x =>
            {
                var rowParts = x.Split(' ');
                
                var timesParts = rowParts[0].Split('-');
                var lowNumber = int.Parse((timesParts[0]).ToString());
                var highNumber = int.Parse((timesParts[1]).ToString());


                var letter = rowParts[1][0];
                var password = rowParts[2];

                return new PasswordPolicy(lowNumber, highNumber, letter, password);
            }).ToList();
    }

    public record PasswordPolicy
    {
        public int LowNumber { get; }
        public int HighNumber { get; }
        public char Letter { get; }
        public string Password { get; }

        public PasswordPolicy(int lowNumber, int highNumber, char letter, string password)
            => (LowNumber, HighNumber, Letter, Password) = (lowNumber, highNumber, letter, password);
    }
}