
var alphaChars = new List<string>()
        {
            "A0Q","B1F","C2G","D3Z","E4X","H5W","I6V","J7S","K8R","L9U"
        };

void Code()
{
    Console.WriteLine("[PROPMT] coding what ? :");
    var input = Console.ReadLine();

    var inputvalue = Convert.ToInt64(input);

    // --- analyzing --- //
    var inputNumLength = input.ToString().Length;
    long first_num = (long)Math.Pow(inputvalue, 2) - 1;
    string hashedId = first_num.ToString() + "-";
    var minValue = Convert.ToInt64(string.Concat("1", string.Concat(Enumerable.Repeat("0", inputNumLength - 1))));
    var maxValue = Convert.ToInt64(string.Concat(Enumerable.Repeat("9", inputNumLength)));
    var randomInt = new Random().NextInt64(minValue: minValue, maxValue: maxValue + 2);
    long randomIntFirstNum = Convert.ToInt64(randomInt.ToString().Substring(0, 1));
    char[] strings = randomInt.ToString().ToCharArray();
    var charsList = String.Join(",", strings);
    var charsLis2 = charsList.Split(",");
    foreach (var num in charsLis2)
    {
        var index = Convert.ToInt32(num);
        var alphaChar = alphaChars[index];
        hashedId += alphaChar;
    }
    // ----------- //
    var letters = hashedId.Split("-").Last();
    long firstNum = Convert.ToInt64(hashedId.Split("-").First());
    long lettersCount = letters.Length;
    hashedId = (firstNum * lettersCount) + "-" + letters;
    Console.WriteLine(hashedId);

}
void Decode()
{
    Console.WriteLine("[PROPMT] decode what ?  :");
    var input = Console.ReadLine();

    // --- split and find the foundamental data about the hashed id --- //
    var splited_hashedId = input.Split("-");
    var hashedId_letters = splited_hashedId.Last();
    var hashedId_first_num = Convert.ToInt64(splited_hashedId.First());
    var hashedId_letters_count = hashedId_letters.Length;

    // --- get the identifier --- //
    var hashedId_identifier = hashedId_first_num / hashedId_letters_count;
    var rawId = Math.Sqrt((hashedId_identifier + 1));
    Console.WriteLine(rawId);
}

while (true)
{
    Console.WriteLine("[SELECT] select :");
    var inputValue = Console.ReadLine();
    if (inputValue == null) continue;
    if (inputValue.ToLower().Trim() == "break") break;

    
    if(inputValue == "code") // --- code --- //
    {
        Code();
    }
    else // --- decode --- //
    {
        Decode();
    }
    
    

    
}



