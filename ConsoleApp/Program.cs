public class Program
{
    public enum PipeType
    {
        Vertical = 1,
        Horizontal,
        BottomRight,
        BottomLeft,
        TopLeft,
        TopRight,
        Cross
    }

    public class Pipe
    {
        private PipeType type;

        private Pipe topAdjacentPipe;
        private Pipe bottomAdjacentPipe;
        private Pipe leftAdjacentPipe;
        private Pipe rightAdjacentPipe;
        private bool hasWater;

        public Pipe(PipeType type)
        {
            this.Type = type;
        }

        public PipeType Type { get => type; set => type = value; }
        public Pipe TopAdjacentPipe { get => topAdjacentPipe; set => topAdjacentPipe = value; }
        public Pipe BottomAdjacentPipe { get => bottomAdjacentPipe; set => bottomAdjacentPipe = value; }
        public Pipe LeftAdjacentPipe { get => leftAdjacentPipe; set => leftAdjacentPipe = value; }
        public Pipe RightAdjacentPipe { get => rightAdjacentPipe; set => rightAdjacentPipe = value; }
        public bool HasWater { get => hasWater; set => hasWater = value; }
    }

    public static void Main()
    {
        string[] state = {"a224C22300000",
         "0001643722B00",
         "0b27275100000",
         "00c7256500000",
         "0006A45000000"};

        Program program = new Program();
        Console.WriteLine(program.solution(state) == 19);
    }

    private Pipe[,] pipes;

    public int solution(string[] state)
    {
        int numOfRow = state.Length;
        int numOfCol = state[0].Length;
        pipes = new Pipe[numOfRow, numOfCol];
        return 0;
    }
}