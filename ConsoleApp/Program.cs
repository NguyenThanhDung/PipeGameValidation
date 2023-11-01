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
        Cross,
        Source,
        Destination
    }

    public class Pipe
    {
        private PipeType type;

        private Pipe topAdjacentPipe;
        private Pipe bottomAdjacentPipe;
        private Pipe leftAdjacentPipe;
        private Pipe rightAdjacentPipe;
        private bool hasWater;

        public PipeType Type { get => type; set => type = value; }
        public Pipe TopAdjacentPipe { get => topAdjacentPipe; set => topAdjacentPipe = value; }
        public Pipe BottomAdjacentPipe { get => bottomAdjacentPipe; set => bottomAdjacentPipe = value; }
        public Pipe LeftAdjacentPipe { get => leftAdjacentPipe; set => leftAdjacentPipe = value; }
        public Pipe RightAdjacentPipe { get => rightAdjacentPipe; set => rightAdjacentPipe = value; }
        public bool HasWater { get => hasWater; set => hasWater = value; }

        public Pipe(char state)
        {
            if (state >= 'a' && state <= 'z')
            {
                this.Type = PipeType.Source;
            }
            else if (state >= 'A' && state <= 'Z')
            {
                this.Type = PipeType.Destination;
            }
            else
            {
                int num = state - '0';
                this.Type = (PipeType)num;
            }
        }
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

        for (int i = 0; i < state.Length; i++)
        {
            for (int j = 0; j < state[i].Length; j++)
            {
                if (state[i][j] != '0')
                {
                    pipes[i, j] = new Pipe(state[i][j]);
                }
            }
        }

        return 0;
    }
}