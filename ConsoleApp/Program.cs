public class Program
{
    public static void Main()
    {
        Program program = new Program();

        string[] state = {"a224C22300000",
            "0001643722B00",
            "0b27275100000",
            "00c7256500000",
            "0006A45000000"};
        Console.WriteLine(program.solution(state) == 19);

        state = new string[] {"0002270003777z24",
            "3a40052001000101",
            "1064000001000101",
            "1006774001032501",
            "1000001001010001",
            "1010001001064035",
            "6227206A0622Z250"};
        Console.WriteLine(program.solution(state) == -48);

        state = new string[] {"3222222400000000", 
            "1000032A40000000", 
            "1000010110000000", 
            "72q227277Q000000", 
            "1000010110000000", 
            "1000062a50000000", 
            "6222222500000000"};
        Console.WriteLine(program.solution(state) == -12);
    }

    public int solution(string[] state)
    {
        return 0;
    }
}