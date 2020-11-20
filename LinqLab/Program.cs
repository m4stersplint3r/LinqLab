using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 2330, 112233, 10, 949, 3764, 2942 };

            List<Student> students = new List<Student>();
            students.Add(new Student("Jimmy", 13));
            students.Add(new Student("Hannah Banana", 21));
            students.Add(new Student("Justin", 30));
            students.Add(new Student("Sarah", 53));
            students.Add(new Student("Hannibal", 15));
            students.Add(new Student("Phillip", 16));
            students.Add(new Student("Maria", 63));
            students.Add(new Student("Abe", 33));
            students.Add(new Student("Curtis", 10));

            // NUMBERS
            // 1
            int minNum = nums.Min(x => x);
            Console.WriteLine("Minimum Number: " + minNum);

            // 2
            int maxNum = nums.Max(x => x);
            Console.WriteLine("Maximum Number: " + maxNum);

            // 3
            int maxNumUnder10K = nums.Where(x => x < 10000).Max();
            Console.WriteLine("Maximum Number under 10000: " + maxNumUnder10K);

            // 4
            List<int> numsBtwn10and100 = nums.Where(x => x > 10 && x < 100).ToList();
            Console.Write("These are nums between 10 and 100: ");
            foreach (int x in numsBtwn10and100)
            {
                Console.Write(x + ", ");
            }
            Console.WriteLine();

            // 5
            List<int> numsBtwnBigNums = nums.Where(x => x >= 100000 && x <= 999999).ToList();
            Console.Write("These are nums between 100000 and 999999: ");
            foreach (int x in numsBtwnBigNums)
            {
                Console.Write(x + ", ");
            }
            Console.WriteLine();

            // 6
            int evenCount = nums.Where(x => x % 2 == 0).ToList().Count;
            Console.WriteLine("There are " + evenCount + " even numbers in the list");
            Console.WriteLine();

            // STUDENTS
            // 1
            var overDrinkingAgeXP = students.Where(s => s.Age >= 21);

            var overDrinkingAge = from s in students
                                  where s.Age >= 21
                                  select s;
            Console.WriteLine("These students can drink:");
            PrintStudentList(overDrinkingAge.ToList());
            PrintStudentList(overDrinkingAgeXP.ToList());

            // 2
            var oldestAge = students.Max(x => x.Age);
            var oldestStudent = students.Where(x => x.Age == oldestAge).First();

            var oldestStudentSQL = from s in students
                                   where s.Age == students.Max(x => x.Age)
                                   select s;

            Console.WriteLine("Oldest student: " + oldestStudentSQL.ToList()[0].Name);

            // 3
            var youngestAge = students.Min(x => x.Age);
            var youngestStudent = students.Where(x => x.Age == youngestAge).First();

            var youngestStudentSQL = from s in students
                                     where s.Age == students.Min(x => x.Age)
                                     select s;

            Console.WriteLine("Youngest student: " + youngestStudent.Name);
            Console.WriteLine("Youngest student w/ SQL: " + youngestStudentSQL.ToList()[0].Name);

            // 4
            List<Student> under25 = (from s in students
                                     where s.Age < 25
                                     select s).ToList();
            int oldestAgeUnder25 = under25.Max(x => x.Age);
            string oldestNameUnder25 = under25.Where(x => x.Age == oldestAgeUnder25).First().Name;

            Console.WriteLine("Oldest student under 25: " + oldestNameUnder25);

            // 5
            var over21 = students.Where(x => x.Age > 21).ToList();
            var over21AndEven = over21.Where(x => x.Age % 2 == 0);
            foreach (var s in over21AndEven)
            {
                Console.WriteLine(s.Name + " is over 21 with an even age of " + s.Age);
            }

            // 6
            var between13and19 = students.Where(x => x.Age >= 13 && x.Age <= 19).ToList();
            foreach (var s in between13and19)
            {
                Console.WriteLine($"{s.Name} is a teenager.");
            }

            // 7
            char[] vowelArray = new[] { 'a', 'e', 'i', 'o', 'u' };
            var nameStartWithVowel = (from s in students
                        where vowelArray.Contains(s.Name.ToLower()[0])
                        select s).ToList();

            foreach (var s in nameStartWithVowel)
            {
                Console.WriteLine($"{s.Name} starts with a vowel");
            }
        }

        public static void PrintStudentList(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}
