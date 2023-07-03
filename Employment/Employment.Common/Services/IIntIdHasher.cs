using Employment.Common.Constants;
using Employment.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Common.Services
{
    public class IntIdHahser : IIntIdHahser
    {
        public readonly IReadOnlyList<string> AlphaChars = new List<string>()
        {
            "A0Q","B1F","C2G","D3Z","E4X","H5W","I6V","J7S","K8R","L9U"
        };

        public string Code(int rawId)
        {
            try
            {
                // --- identifier --- //
                long hash_identifier = (long)Math.Pow(rawId, 2) - 1;
                string hashedId = hash_identifier.ToString() + "-";

                int rawIdLength = rawId.ToString().Length;
                long minValue = Convert.ToInt64(string.Concat("1", string.Concat(Enumerable.Repeat("0", rawIdLength - 1))));
                long maxValue = Convert.ToInt64(string.Concat(Enumerable.Repeat("9", rawIdLength)));
                long randomInt = new Random().NextInt64(minValue: minValue, maxValue: maxValue + 2);

                // --- add letters to the hashed id --- //
                char[] randomIntCharNums = randomInt.ToString().ToCharArray();
                string[] numbersArray = string.Join(",", randomIntCharNums).Split(",");
                foreach (var num in numbersArray)
                {
                    string alphabetChar = AlphaChars[Convert.ToInt32(num)];
                    hashedId += alphabetChar;
                }

                // --- modify hashed id --- //
                var hashedId_letters = hashedId.Split("-").Last();
                long hashedId_identifier = Convert.ToInt64(hashedId.Split("-").First());
                long hashedId_letters_count = hashedId_letters.Length;

                // --- regenerate the hashed id --- //
                hashedId = hashedId_identifier * hashedId_letters_count + "-" + hashedId_letters;

                return hashedId;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException();
            }
        }

        public int DeCode(string hashId)
        {
            try
            {
                // --- split and find the foundamental data about the hashed id --- //
                string[] splited_hashedId = hashId.Split("-");
                string hashedId_letters = splited_hashedId.Last();
                long hashedId_first_num = Convert.ToInt64(splited_hashedId.First());
                int hashedId_letters_count = hashedId_letters.Length;

                // --- get the identifier --- //
                long hashedId_identifier = hashedId_first_num / hashedId_letters_count;
                double rawId = Math.Sqrt((hashedId_identifier + 1));

                return Convert.ToInt32(rawId);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
