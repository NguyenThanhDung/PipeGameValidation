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
        private char name;
        private Dictionary<Direction, Pipe> adjacentPipes;
        private bool hasWater;

        public PipeType Type { get => type; set => type = value; }
        public bool HasWater { get => hasWater; set => hasWater = value; }
        public Dictionary<Direction, Pipe> AdjacentPipes { get => adjacentPipes; }
        public char Name { get => name; set => name = value; }

        public static bool IsCorresponding(Pipe pipe1, Pipe pipe2)
        {
            return char.ToLower(pipe1.Name) == char.ToLower(pipe2.Name);
        }

        public Pipe(char state)
        {
            if (state >= 'a' && state <= 'z')
            {
                this.Type = PipeType.Source;
                this.name = state;
            }
            else if (state >= 'A' && state <= 'Z')
            {
                this.Type = PipeType.Destination;
                this.name = state;
            }
            else
            {
                int num = state - '0';
                this.Type = (PipeType)num;
                this.name = '\0';
            }

            adjacentPipes = new Dictionary<Direction, Pipe>();
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
                            adjacentPipes.Add(Direction.Top, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Bottom, nextPipe);
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
                            adjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else if (direction == Direction.Right)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Right, nextPipe);
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
                            adjacentPipes.Add(Direction.Right, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Bottom, nextPipe);
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
                            adjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Bottom, nextPipe);
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
                            adjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else if (direction == Direction.Top)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Top, nextPipe);
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
                            adjacentPipes.Add(Direction.Top, nextPipe);
                    }
                    else if (direction == Direction.Right)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Right, nextPipe);
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
                            adjacentPipes.Add(Direction.Top, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Bottom, nextPipe);
                    }
                    else if (direction == Direction.Left)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            adjacentPipes.Add(Direction.Right, nextPipe);
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
        int minSequenceLength = int.MaxValue;
        List<List<Pipe>> sequences = new List<List<Pipe>>();

        List<Pipe> sources = GetSources(pipes);
        foreach (var source in sources)
        {
            foreach (var direction in source.AdjacentPipes.Keys)
            {
                var nextPipe = source.AdjacentPipes[direction];

                List<Pipe> sequence = new List<Pipe>();
                sequence.Add(source);
                sequence.Add(nextPipe);

                Pipe previousPipe = source;
                Pipe currentPipe = nextPipe;

                while (true)
                {
                    nextPipe = FindNextPipe(pipes, currentPipe, previousPipe);

                    if (nextPipe == null ||
                        (nextPipe.Type == PipeType.Destination &&
                        Pipe.IsCorresponding(nextPipe, sequence[0]) == false))
                    {
                        if ((sequence.Count - 1) < minSequenceLength)
                            minSequenceLength = sequence.Count - 1;
                        break;
                    }

                    if (nextPipe.Type == PipeType.Destination)
                        break;

                    previousPipe = currentPipe;
                    currentPipe = nextPipe;
                    sequence.Add(nextPipe);
                }

                sequences.Add(sequence);
            }
        }

        List<Pipe> filledPipes = new List<Pipe>();
        if (minSequenceLength == int.MaxValue)
        {
            foreach (var sequence in sequences)
            {
                filledPipes.AddRange(sequence);
            }
        }
        else
        {
            foreach (var sequence in sequences)
            {
                for (int i = 0; i < sequence.Count && i < minSequenceLength; i++)
                {
                    filledPipes.Add(sequence[i]);
                }
            }
        }

        filledPipes = filledPipes.Distinct().ToList();
        foreach (var source in sources)
            filledPipes.Remove(source);

        int count = filledPipes.Distinct().ToList().Count;
        return minSequenceLength == int.MaxValue ? count : -count;
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

    private Pipe FindNextPipe(Pipe[,] pipes, Pipe currentPipe, Pipe previousPipe)
    {
        if (currentPipe.Type == PipeType.Cross)
        {
            foreach (var direction in currentPipe.AdjacentPipes.Keys)
            {
                var pipe = currentPipe.AdjacentPipes[direction];
                if (pipe == previousPipe)
                {
                    var oppositeDirection = GetOppositeDirection(direction);
                    return currentPipe.AdjacentPipes[oppositeDirection];
                }
            }
        }
        else
        {
            foreach (var direction in currentPipe.AdjacentPipes.Keys)
            {
                var nextPipe = currentPipe.AdjacentPipes[direction];
                if (nextPipe != previousPipe)
                    return nextPipe;
            }
        }
        return null;
    }

    private Direction GetOppositeDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Top:
                return Direction.Bottom;
            case Direction.Bottom:
                return Direction.Top;
            case Direction.Left:
                return Direction.Right;
            default:
                return Direction.Left;
        }
    }
}