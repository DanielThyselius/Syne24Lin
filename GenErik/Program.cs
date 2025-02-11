Console.WriteLine("Hello, World!");



Func<int, bool> isDivisibleByThree = x => x % 3 == 0;

var list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine(DoSomethingCool(5,0));

static int DoSomethingCool(int a, int b) {
    var result = 0;
    try
    {
        result = a / b;
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine("Can't divide by zero...");
        return 42;
    }
    finally
    {
        Console.WriteLine("We did something cool!");
    }
    return result;
}
Console.ReadKey();






var gen = new GenericClass<bool, Dog>();

var dog = new Dog();
gen.A = false;
//gen.B = dog;
var divisebleByThree = list.Where(isDivisibleByThree).ToList();

foreach (var item in divisebleByThree)
{
    Console.WriteLine(item);
}
Console.ReadKey();


Func<int, int, string> test = (x, y) => $"Hello, {x} * {y} = {x * y}";

Func<string> stringFunc = () => "Hello ";

Console.WriteLine(test(5, 6));

Console.WriteLine(stringFunc());

Console.WriteLine(gen.ToString());
Console.ReadKey();

public class GenericClass<T1, T2>() where T1 : struct where T2 : Animal
{
    public T1 A { get; set; }
    public T2 B { get; set; }

    public (T1 Value1, T2 Value2) GetValues()
    {
        return (A, B);
    }

    public override string ToString()
    {
        return "A: " + A.ToString() + "\nB: " + B.Feed();
    }
}

public abstract class Animal
{
    public abstract string Feed();
}

public class Dog : Animal
{
    public override string Feed()
    {
        //throw new DivideByZeroException();
        return "Woof, I'm eating";
    }
}
