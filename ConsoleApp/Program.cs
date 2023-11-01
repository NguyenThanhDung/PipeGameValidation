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
        private Dictionary<Direction, Pipe> adjacentPipes;
        private Dictionary<Direction, bool> waterPresences;

        public PipeType Type { get => type; }
        public Dictionary<Direction, Pipe> AdjacentPipes { get => adjacentPipes; }
        public Dictionary<Direction, bool> WaterPresences { get => waterPresences; }

        public bool HasWater
        {
            get
            {
                foreach (var direction in waterPresences.Keys)
                {
                    if (waterPresences[direction])
                        return true;
                }
                return false;
            }
        }

        public Pipe(char state)
        {
            if (state >= 'a' && state <= 'z')
            {
                this.type = PipeType.Source;
            }
            else if (state >= 'A' && state <= 'Z')
            {
                this.type = PipeType.Destination;
            }
            else
            {
                int num = state - '0';
                this.type = (PipeType)num;
            }

            this.adjacentPipes = new Dictionary<Direction, Pipe>();

            this.waterPresences = new Dictionary<Direction, bool>();
            switch (this.type)
            {
                case PipeType.Vertical:
                    this.waterPresences.Add(Direction.Top, false);
                    this.waterPresences.Add(Direction.Bottom, false);
                    break;
                case PipeType.Horizontal:
                    this.waterPresences.Add(Direction.Left, false);
                    this.waterPresences.Add(Direction.Right, false);
                    break;
                case PipeType.BottomRight:
                    this.waterPresences.Add(Direction.Bottom, false);
                    this.waterPresences.Add(Direction.Right, false);
                    break;
                case PipeType.BottomLeft:
                    this.waterPresences.Add(Direction.Bottom, false);
                    this.waterPresences.Add(Direction.Left, false);
                    break;
                case PipeType.TopLeft:
                    this.waterPresences.Add(Direction.Top, false);
                    this.waterPresences.Add(Direction.Left, false);
                    break;
                case PipeType.TopRight:
                    this.waterPresences.Add(Direction.Top, false);
                    this.waterPresences.Add(Direction.Right, false);
                    break;
                default:
                    this.waterPresences.Add(Direction.Top, false);
                    this.waterPresences.Add(Direction.Bottom, false);
                    this.waterPresences.Add(Direction.Left, false);
                    this.waterPresences.Add(Direction.Right, false);
                    break;
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
                            this.AdjacentPipes.Add(Direction.Top, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Bottom, nextPipe);
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
                            this.AdjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else if (direction == Direction.Right)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Right, nextPipe);
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
                            this.AdjacentPipes.Add(Direction.Right, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Bottom, nextPipe);
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
                            this.AdjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Bottom, nextPipe);
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
                            this.AdjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else if (direction == Direction.Top)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Top, nextPipe);
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
                            this.AdjacentPipes.Add(Direction.Top, nextPipe);
                    }
                    else if (direction == Direction.Right)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Right, nextPipe);
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
                            this.AdjacentPipes.Add(Direction.Top, nextPipe);
                    }
                    else if (direction == Direction.Bottom)
                    {
                        if (nextPipe.Type == PipeType.Vertical
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Bottom, nextPipe);
                    }
                    else if (direction == Direction.Left)
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomRight
                            || nextPipe.Type == PipeType.TopRight
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Left, nextPipe);
                    }
                    else
                    {
                        if (nextPipe.Type == PipeType.Horizontal
                            || nextPipe.Type == PipeType.BottomLeft
                            || nextPipe.Type == PipeType.TopLeft
                            || nextPipe.Type == PipeType.Cross
                            || nextPipe.Type == PipeType.Source
                            || nextPipe.Type == PipeType.Destination)
                            this.AdjacentPipes.Add(Direction.Right, nextPipe);
                    }
                    break;
                default:
                    break;
            }
        }

        public void PourWater(Direction pourDirection)
        {
            switch (type)
            {
                case PipeType.Vertical:
                    if (pourDirection == Direction.Top || pourDirection == Direction.Bottom)
                    {
                        waterPresences[Direction.Top] = true;
                        waterPresences[Direction.Bottom] = true;
                    }
                    break;
                case PipeType.Horizontal:
                    if (pourDirection == Direction.Left || pourDirection == Direction.Right)
                    {
                        waterPresences[Direction.Left] = true;
                        waterPresences[Direction.Right] = true;
                    }
                    break;
                case PipeType.BottomRight:
                    if (pourDirection == Direction.Bottom || pourDirection == Direction.Right)
                    {
                        waterPresences[Direction.Bottom] = true;
                        waterPresences[Direction.Right] = true;
                    }
                    break;
                case PipeType.BottomLeft:
                    if (pourDirection == Direction.Bottom || pourDirection == Direction.Left)
                    {
                        waterPresences[Direction.Bottom] = true;
                        waterPresences[Direction.Left] = true;
                    }
                    break;
                case PipeType.TopRight:
                    if (pourDirection == Direction.Top || pourDirection == Direction.Right)
                    {
                        waterPresences[Direction.Top] = true;
                        waterPresences[Direction.Right] = true;
                    }
                    break;
                case PipeType.TopLeft:
                    if (pourDirection == Direction.Top || pourDirection == Direction.Left)
                    {
                        waterPresences[Direction.Top] = true;
                        waterPresences[Direction.Left] = true;
                    }
                    break;
                case PipeType.Cross:
                case PipeType.Source:
                    if (pourDirection == Direction.Top || pourDirection == Direction.Bottom)
                    {
                        waterPresences[Direction.Top] = true;
                        waterPresences[Direction.Bottom] = true;
                    }
                    if (pourDirection == Direction.Left || pourDirection == Direction.Right)
                    {
                        waterPresences[Direction.Left] = true;
                        waterPresences[Direction.Right] = true;
                    }
                    break;
                default:    // Destination
                    waterPresences[pourDirection] = true;
                    break;
            }
        }
    }

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
        Pipe[,] pipes = ParseState(state);
        pipes = FindConnections(pipes);
        pipes = PourWater(pipes);
        return CountWaterPipe(pipes);
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

    private Pipe[,] PourWater(Pipe[,] pipes)
    {
        Queue<Pipe> queue = new Queue<Pipe>();

        foreach (var pipe in pipes)
        {
            if (pipe != null && pipe.Type == PipeType.Source)
            {
                foreach (var direction in pipe.WaterPresences.Keys)
                    pipe.WaterPresences[direction] = true;
                queue.Enqueue(pipe);
            }
        }

        while (queue.Count > 0)
        {
            var pipe = queue.Dequeue();
            foreach (var direction in pipe.AdjacentPipes.Keys)
            {
                var adjacentPipe = pipe.AdjacentPipes[direction];
                var oppositeDirection = GetOpositeDirection(direction);
                if (pipe.WaterPresences[direction] == true
                    && adjacentPipe.WaterPresences[oppositeDirection] == false)
                {
                    adjacentPipe.PourWater(oppositeDirection);
                    if (adjacentPipe.Type != PipeType.Destination)
                        queue.Enqueue(adjacentPipe);
                }
            }
        }

        return pipes;
    }

    private int CountWaterPipe(Pipe[,] pipes)
    {
        int count = 0;
        bool filledAllDestinations = true;
        foreach (var pipe in pipes)
        {
            if (pipe == null || pipe.Type == PipeType.Source)
                continue;

            if (pipe.Type == PipeType.Destination)
            {
                if (!pipe.HasWater)
                    filledAllDestinations = false;
                continue;
            }

            bool hasWater = false;
            foreach (var direction in pipe.WaterPresences.Keys)
            {
                if (pipe.WaterPresences[direction])
                {
                    hasWater = true;
                    break;
                }
            }
            if (hasWater)
            {
                count++;
            }
        }
        return filledAllDestinations ? count : -count;
    }

    private Direction GetOpositeDirection(Direction direction)
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