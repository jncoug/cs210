// return (x+y)*z and x*y + y*z.

Console.WriteLine("Enter first number");
int first = int.Parse(Console.ReadLine());

Console.WriteLine("Enter second number");
int second = int.Parse(Console.ReadLine());

Console.WriteLine("Enter third number");
int third = int.Parse(Console.ReadLine());

int answer1 = (first+second)*third;

int answer2 = (first*second) + (second*third);

Console.WriteLine($"Result of specified numbers {first}, {second} and {third}, (x+y)*z is {answer1} and x*y + y*z is {answer2}");