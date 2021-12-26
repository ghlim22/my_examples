using System;

namespace example73_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Birthday(yyyy/mm/dd)");
            string birthday = Console.ReadLine();
            string[] birthdaySplit = birthday.Split('/');

            uint.TryParse(birthdaySplit[0], out uint bYear);
            uint.TryParse(birthdaySplit[1], out uint bMonth);
            uint.TryParse(birthdaySplit[2], out uint bDay);

            uint age = Age.GetTotalDays(bYear, bMonth, bDay);
            Console.WriteLine($"Days past since you're born: {age}");
        }
    }
}
