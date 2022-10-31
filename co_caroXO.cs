class Board
{
    int BoardWidth { get; set; }
    int BoardSize { get; set; }

    //Constructor that gets the size and width of the board to use in drawing the board
    public Board(int boardSize, int boardWidth)
    {
        BoardWidth = boardWidth;
        BoardSize = boardSize;
    }
    public void DrawBoard(char[] board, bool onlyNums)
    {
        Program p = new Program();
        // Used to create the rows
        int rowCount = 0;

        Console.WriteLine("\n\n");

        // Loop through board pieces and draw what´s is in each slot
        for (int i = 0; i < BoardSize; i++)
        {
            // Draw whats one the board at this place
            if (onlyNums)
            {
                // Display board number
                Console.Write(i);

                // if it's not the last item on the row add a separator bar
                if (rowCount < (BoardWidth))
                {
                    if (i < 10)
                        Console.Write("  |  ");
                    else
                        Console.Write(" |  ");
                }
            }
            else
            {   //Board without numbers
                // Display the X, O, or ampty from the board
                Console.Write(board[i]);

                // if it's not the last item on the row, add a separator bar
                if (rowCount < (BoardWidth))
                {
                    if (i < 10)
                        Console.Write(" | ");
                    else
                        Console.Write(" | ");
                }
            }

            // Keeps track of how many items are on this row
            rowCount++;

            // if this row is long enough one row is created
            if (rowCount == BoardWidth)
            {

                Console.WriteLine();

                // determine how many hyphens there should be for the separator bar, based
                // on whether we're showing the number board or the actual tictactoe board.
                int actualWidth;
                if (onlyNums)
                    actualWidth = BoardWidth * 5;
                else
                    actualWidth = BoardWidth * 3;

                // draw the separator bar
                for (int line = 0; line <= actualWidth + 2; line++)
                    Console.Write("-");


                Console.WriteLine();

                // reset the row count
                rowCount = 0;
            }
        }

        Console.WriteLine("\n\n");
    }

}
class ComputerPlayer : Player
{


    public ComputerPlayer(int boardSize, int boardWidth) : base(boardSize, boardWidth)
    {
        BoardWidth = boardWidth;
        BoardSize = boardSize;
    }

    //Method that asks the computerplayer for a move in 3x3 game
    public int AskForComputerMoveThree(char[] board, char turn)
    {
        Random rnd = new Random();
        int input;

        // Ask for players move
        Console.Write("Player " + turn + ". Make your move (0 - " + (BoardSize - 1) + "): ");
        input = rnd.Next(0, 8);//Random number for where the computer wan´t to place it´s marker

        // Make the move
        while (true)
        {
            bool validMove = MakeMove(board, turn, input);
            if (validMove == false)
            {
                Console.Write("Pick a new location (0 - " + (BoardSize - 1) + "): ");
                //New random number to pick a new location if space is occupied or invalid
                input = rnd.Next(0, 8);
            }
            else
                break;
        }

        return input;
    }

    //Method that asks the computerplayer for a move in 5x5 game
    public int AskForComputerMoveFive(char[] board, char turn)
    {
        Random rnd = new Random();
        int input;

        // Ask for players move
        Console.Write("Player " + turn + ". Make your move (0 - " + (BoardSize - 1) + "): ");
        input = rnd.Next(0, 24);

        // Make the move
        while (true)
        {
            bool validMove = MakeMove(board, turn, input);
            if (validMove == false)
            {
                Console.Write("Pick a new location (0 - " + (BoardSize - 1) + "): ");
                input = rnd.Next(0, 24);
            }
            else
                break;
        }

        return input;
    }

    new public bool MakeMove(char[] board, char turn, int move)
    {
        // Make sure the user chose a valid tile
        if (move < 0 || move > BoardSize)
        {
            Console.Write("This is not a valid tile.\n");
            return false;
        }

        // If the location is empty...
        if (board[move] == empty)
        {
            // place the user's mark in that location
            board[move] = turn;

            // Keeps track of the number of tiles which have an X or O in them 
            moveCount += 1;

            return true;
        }
        else
        {
            Console.Write("That slot is already taken.\n");
            return false;
        }
    }


}
class Player
{

    public const char empty = ' ';
    public int moveCount = 0;
    public int BoardWidth { get; set; }
    public int BoardSize { get; set; }

    public Player(int boardSize, int boardWidth)
    {
        BoardWidth = boardWidth;
        BoardSize = boardSize;
    }

    public int AskForMove(char[] board, char turn)
    {
        int input;

        // Ask for players move
        Console.Write("Player " + turn + ". Make your move (0 - " + (BoardSize - 1) + "): ");
        input = Convert.ToInt32(Console.ReadLine());

        // Make the move
        while (true)
        {
            bool validMove = MakeMove(board, turn, input);
            if (validMove == false)
            {
                Console.Write("Pick a new location (0 - " + (BoardSize - 1) + "): ");
                input = Convert.ToInt32(Console.ReadLine());
            }

            else
                break;
        }

        return input;
    }

    public bool MakeMove(char[] board, char turn, int move)
    {
        // Make sure the user chose a valid tile
        if (move < 0 || move > BoardSize)
        {
            Console.Write("This is not a valid tile.\n");
            return false;
        }

        // If the location is empty...
        if (board[move] == empty)
        {
            // place the user's mark in that location
            board[move] = turn;

            // Keeps track of the number of tiles which have an X or O in them 
            moveCount += 1;

            return true;
        }
        else
        {
            Console.Write("That slot is already taken.\n");
            return false;
        }
    }
    // Method to determine winner by checking diagonal right,diagonal left,across and down (down not yet working for 5X5 game)
    //parameters: board -the tic-tac-toe game board, turn - X or O, arraySize- number of tiles user (X or O) has selected 
    public bool IsWinner(char[] board, char turn, int arraySize)
    {
        // Check for a win across (all game types +1)
        for (int i = 0; i < BoardSize; i += BoardWidth)
        {
            if (CheckForWin(board, turn, 1, i, i + BoardWidth) == true)
            {
                return true;
            }
        }

        // Check for a win diagonal right (standard 3 game, +2 (ex. 2, 4, 6))
        int diagRight = 2 + (BoardWidth - 3);
        if (CheckForWin(board, turn, diagRight, (BoardWidth - 1), (diagRight * BoardWidth) + 1) == true)
        {
            return true;
        }

        // Check for a win down starting at 0, 1, or 2 in standard game (standard 3 game, +3 (ex. 1, 4, 7))
        for (int i = 0; i < BoardWidth; i++)
        {
            if (CheckForWin(board, turn, 3 + (BoardWidth - 3), i, ((BoardWidth * 2) + i) + 1) == true)
            {
                return true;
            }
        }

        // Check for a win diagonal left (standard 3 game, +4 (ex. 0, 3, 8))
        if (CheckForWin(board, turn, 4 + (BoardWidth - 3), 0, BoardSize) == true)
        {
            return true;
        }

        //No win
        return false;
    }

    public bool IsDraw()
    {
        // Check to see if board is full
        if (moveCount >= BoardSize)
            return true;

        return false;
    }

    public bool CheckForWin(char[] board, char turn, int spaceCount, int iStart, int iEnd)
    {
        // Count number of tiles user has in a row. 
        int tileCount = 0;

        // Check for a win
        for (int i = iStart; i < iEnd; i += spaceCount)
        {
            // Check to see if the user's tile is on the board at the specified location
            if (board[i] == turn)
            {
                tileCount += 1;
            }

            // If the user has enough tiles in a row it´s a win
            if (tileCount == BoardWidth)
            {
                return true;
            }
        }

        return false;
    }
}
class Program
{

    const char player1 = 'X';//Constants to store the mark
    const char player2 = 'O';//of player 1 and 2
    const char empty = ' '; //Char to empty the boarditems
    int boardWidth = 3;
    int boardSize = 9;


    static int Main(string[] args)
    {
        Program p = new Program();
        char gameOn = 'y';//keeps track if game is ongoing
        int input;//variable to keep track of players choice of boardsize


        while (gameOn == 'y')
        {
            // get the size of the board that the user wants
            Console.Write("\nWelcome to Tic-Tac-Toe!\n\n");
            Console.Write("1. 3x3 (Standard)\n");
            Console.Write("2. 5x5\n");
            Console.Write("\nWhat size do you want on the board? (3 or 5): ");

            input = Convert.ToInt32(Console.ReadLine());

            // set the board size, based on the user's input
            if (input == 3 || input == 5)
            {
                p.boardWidth = input;
                p.boardSize = p.boardWidth * p.boardWidth;
            }
            else
            {
                Console.WriteLine("\nYou entered an invalid size!Try again! \n\n");
                continue;

            }



            // Array for the board
            char[] board = new char[p.boardSize];

            // Set all of the board items to empty
            for (int i = 0; i < p.boardSize; i++)
                board[i] = empty;

            bool win = false;
            int size = p.boardSize;//Varibles for the boardssize to pass as parameters in methodcallings
            int width = p.boardWidth;//pass as parameters in methodcallings

            Console.WriteLine("\nChoose opponent\n");
            Console.WriteLine("1. Human opponent");
            Console.WriteLine("2. Computer ");
            int chosenOpponent = int.Parse(Console.ReadLine());//Player input if they want to play 
                                                               //against another human or the computerplayer

            // Draw the board
            Console.WriteLine();
            Console.Write(@"The board looks like this and you choose your position by entering the number
            representing the position you want:");
            Player play = new Player(size, width);
            Board b = new Board(size, width);
            ComputerPlayer cp = new ComputerPlayer(size, width);
            // reset moveCount
            play.moveCount = 0;
            b.DrawBoard(board, true);
            Console.WriteLine("\n\n");

            while (win == false)//While there is no winner
            {
                // Ask player1 for a move
                play.AskForMove(board, player1);

                // Draw the board
                b.DrawBoard(board, false);



                // Check to see if player 1 has won
                win = false;
                win = play.IsWinner(board, player1, size);
                if (win == true)
                {
                    Console.WriteLine("\n\nPlayer X has won!\n\n");
                    break;
                }

                // Check for a draw
                if (play.IsDraw())
                {
                    Console.WriteLine("\n\nIt's a draw!\n\n");
                    break;
                }

                // Ask player2 for a move 
                if (chosenOpponent == 2 && input == 3)//If player wanted computer opponent and a 3x3board
                    cp.AskForComputerMoveThree(board, player2);

                else if (chosenOpponent == 2 && input == 5)//If player wanted computer opponent and a 5x5 board
                    cp.AskForComputerMoveFive(board, player2);

                else
                    play.AskForMove(board, player2);//If player wanted human opponent

                // Draw board again
                b.DrawBoard(board, false);

                // Check to see if player 2 has won
                win = false;
                win = play.IsWinner(board, player2, size);
                if (win == true)
                {
                    Console.Write("\n\nPlayer O has won!\n\n");
                    break;
                }

                // Check for a draw again
                if (play.IsDraw())
                {
                    Console.Write("\n\nIt's a draw!\n\n");
                    break;
                }
            }

            // Ask if player want to play again
            Console.WriteLine("\n\nWould you like to play again? (y/n): ");
            gameOn = Convert.ToChar(Console.ReadLine());

            //If the player don´t want to play again exit the application else start new game
            if (gameOn == 'n')
                Environment.Exit(0);

            else
                continue;
            Console.ReadKey();
        }

        return 0;

    }
}