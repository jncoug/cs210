using System.Collections.Generic;


List<int> nums = new List<int>();
List<int> sortednums = new List<int>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");
int input=1;

while (input != 0) {
    input = int.Parse(Console.ReadLine());
    if (input!=0)
        nums.Add(input);
}

// tell sum
int sum = 0;
foreach (int num in nums) {
    sum+=num;
}
Console.WriteLine($"The sum is {sum}");
// tell average
float avg = (float)sum / (float)nums.Count();
Console.WriteLine($"The avg is {avg}");
// tell largest
int largest=0;
foreach (int num in nums) {
    if (num > largest)
        largest = num;
}
Console.WriteLine($"The largest is {largest}");

int x = int.Parse(Console.ReadLine());


