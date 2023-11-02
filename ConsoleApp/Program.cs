public class Program
{
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

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
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

        public void TryConnect(Direction direction, Pipe nextPipe)
        {
            if (nextPipe == null)
                return;
            switch (this.Type)
            {
                case PipeType.Vertical:
                    if (direction == Direction.Top)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.TopAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.bottomAdjacentPipe = nextPipe;
                    }
                    break;
                case PipeType.Horizontal:
                    if (direction == Direction.Left)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.leftAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Right)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.rightAdjacentPipe = nextPipe;
                    }
                    break;
                case PipeType.BottomRight:
                    if (direction == Direction.Right)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.rightAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.bottomAdjacentPipe = nextPipe;
                    }
                    break;
                case PipeType.BottomLeft:
                    if (direction == Direction.Left)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.leftAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.bottomAdjacentPipe = nextPipe;
                    }
                    break;
                case PipeType.TopLeft:
                    if (direction == Direction.Left)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.leftAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Top)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.TopAdjacentPipe = nextPipe;
                    }
                    break;
                case PipeType.TopRight:
                    if (direction == Direction.Top)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.TopAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Right)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.rightAdjacentPipe = nextPipe;
                    }
                    break;
                case PipeType.Cross:
                case PipeType.Source:
                case PipeType.Destination:
                    if (direction == Direction.Top)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.TopAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.bottomAdjacentPipe = nextPipe;
                    }
                    else if (direction == Direction.Left)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.leftAdjacentPipe = nextPipe;
                    }
                    else
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.rightAdjacentPipe = nextPipe;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public int solution(string[] state)
    {
        Pipe[,] pipes = ParseState(state);
        pipes = FindConnections(pipes);
        return Process(pipes);
    }

    private Pipe[,] ParseState(string[] state)
    {
        int numOfRow = state.Length;
        int numOfCol = state[0].Length;
        Pipe[,] pipes = new Pipe[numOfRow, numOfCol];

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
        return pipes;
    }

    private Pipe[,] FindConnections(Pipe[,] pipes)
    {
        for (int i = 0; i < pipes.GetLength(0); i++)
        {
            for (int j = 0; j < pipes.GetLength(1); j++)
            {
                if (pipes[i, j] == null)
                    continue;
                if (i > 0)
                {
                    Pipe topPipe = pipes[i - 1, j];
                    pipes[i, j].TryConnect(Direction.Top, topPipe);
                }
                if (i < pipes.GetLength(0) - 1)
                {
                    Pipe bottomPipe = pipes[i + 1, j];
                    pipes[i, j].TryConnect(Direction.Bottom, bottomPipe);
                }
                if (j > 0)
                {
                    Pipe leftPipe = pipes[i, j - 1];
                    pipes[i, j].TryConnect(Direction.Left, leftPipe);
                }
                if (j < pipes.GetLength(1) - 1)
                {
                    Pipe rightPipe = pipes[i, j + 1];
                    pipes[i, j].TryConnect(Direction.Right, rightPipe);
                }
            }
        }
        return pipes;
    }

    private int Process(Pipe[,] pipes)
    {
        List<Pipe> sources = GetSources(pipes);
        return 0;
    }

    private List<Pipe> GetSources(Pipe[,] pipes)
    {
        List<Pipe> sources = new List<Pipe>();
        foreach (var pipe in pipes)
        {
            if (pipe != null && pipe.Type == PipeType.Source)
                sources.Add(pipe);
        }
        return sources;
    }
}