namespace Day2
{
    enum MOVE
    {
        ROCK,
        PAPER,
        SCISSOR
    }
    public class Day2
    {
        const int WIN_POINTS = 6;
        const int DRAW_POINTS = 3;
        const int LOSE_POINTS = 0;

        const int ROCK_POINTS = 1;
        const int PAPER_POINTS = 2;
        const int SCISSOR_POINTS = 3;


        const char OPPONENT_ROCK = 'A';
        const char OPPONENT_PAPER = 'B';
        const char OPPONENT_SCISSOR = 'C';

        const char PLAYER_ROCK = 'X';
        const char PLAYER_PAPER = 'Y';
        const char PLAYER_SCISSOR = 'Z';

        const char LOSE = 'X';
        const char DRAW = 'Y';
        const char WIN = 'Z';

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            var totalPoints = 0;
            foreach(var line in lines)
            {
                var opponent = ParseMove(line[0]);
                var player = ParseMove(line[2]);
                var result = line[2];
                if (opponent == player)
                {
                    //draw
                    totalPoints += DRAW_POINTS + MovePoints(player);
                }
                else if(Winner(opponent, player) == 1)
                {
                    totalPoints += WIN_POINTS + MovePoints(player);
                }
                else
                {
                    totalPoints += LOSE_POINTS + MovePoints(player);
                }
            }
            Console.WriteLine(totalPoints);
            totalPoints = 0;

            foreach (var line in lines)
            {
                var opponent = ParseMove(line[0]);
                var player = ParseMove(line[2]);
                var result = line[2];
                var expectedMove = MoveFromResult(opponent, result);
                totalPoints += MovePoints(expectedMove);
                if (result == WIN)
                {
                    totalPoints += WIN_POINTS;
                }
                else if (result == DRAW)
                {
                    totalPoints += DRAW_POINTS;
                }
            }
            
            Console.WriteLine(totalPoints);
        }

        static MOVE MoveFromResult(MOVE opponent, char result)
        {
            if (result == DRAW)
            {
                return opponent;
            }
            if (result == WIN)
            {
                if (opponent == MOVE.ROCK)
                {
                    return MOVE.PAPER;
                }

                if (opponent == MOVE.PAPER)
                {
                    return MOVE.SCISSOR;
                }

                if (opponent == MOVE.SCISSOR)
                {
                    return MOVE.ROCK;
                }
            }
            if (result == LOSE)
            {
                if (opponent == MOVE.ROCK)
                {
                    return MOVE.SCISSOR;
                }

                if (opponent == MOVE.PAPER)
                {
                    return MOVE.ROCK;
                }

                if (opponent == MOVE.SCISSOR)
                {
                    return MOVE.PAPER;
                }
            }
            return 0;
        }

        static int Winner(MOVE opponent, MOVE player)
        {
            if ((opponent == MOVE.ROCK && player == MOVE.SCISSOR) ||
                (opponent == MOVE.SCISSOR && player == MOVE.PAPER) ||
                (opponent == MOVE.PAPER && player == MOVE.ROCK))
            {
                return 0;
            }
            return 1;
        }

        static MOVE ParseMove(char move)
        {
            switch(move)
            {
                case PLAYER_ROCK:
                case OPPONENT_ROCK:
                    return MOVE.ROCK;
                case PLAYER_PAPER:
                case OPPONENT_PAPER:
                    return MOVE.PAPER;
                case PLAYER_SCISSOR:
                case OPPONENT_SCISSOR:
                    return MOVE.SCISSOR;
            }
            return 0;
        }

        static int MovePoints(MOVE move)
        {
            switch(move)
            {
                case MOVE.ROCK:
                    return ROCK_POINTS;
                case MOVE.PAPER:
                    return PAPER_POINTS;
                case MOVE.SCISSOR:
                    return SCISSOR_POINTS;
            }
            return 0;
        }
    }
}