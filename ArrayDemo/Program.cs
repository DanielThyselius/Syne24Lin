var test = new String[5];

for (int i = 0; i < test.Length; i++)
{
    test[i] = Console.ReadKey().KeyChar.ToString();
}
Console.WriteLine("Backwards that is: ");

for (int i = test.Length -1; i >= 0 ; i--)
{
    Console.Write(test[i]);
}

test[8] = "a";

