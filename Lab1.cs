
using System;

namespace ProjectOne
{


    public class Game
    {
        public GameAccount player;
        public GameAccount enemy;
        public int raiting;
        public Boolean status;
        public static int id = 0;
        public  int index;

        public Game(GameAccount player, GameAccount player2, int raiting, Boolean status)
        {
            this.player = player;
            this.enemy = player2;
            this.raiting = raiting;
            this.status = status;
            id++;
            index = id;
        }

    }



    public class GameAccount
    {
        private string UserName ;

        private int CurrentRating ;

        public int GamesCount { get; set; }
       
       

        private List<Game> historyGames = new List<Game>();

        public GameAccount(string UserName)
        {
            this.UserName = UserName;
            this.CurrentRating = 1;


        }

        public void playGame(GameAccount opponentName, int rating)
        {
            if (rating <= 0)
            {
               
                throw new ArgumentOutOfRangeException("The current rating cannot be less than zero");

            }
            Random random = new Random();
            Boolean statusWin = random.Next(0, 1) == 1;
            if (statusWin)
            {
                WinGame(opponentName, rating);
            }
            else
            {
                LoseGame(opponentName, rating);
            }
            this.GamesCount++;
            opponentName.GamesCount++;
           
            this.historyGames.Add(new Game(this, opponentName, rating, statusWin));
            opponentName.historyGames.Add(new Game(opponentName, this, rating, !statusWin));
        }

        public void WinGame(GameAccount opponentName, int rating)
        {

            CurrentRating += rating;
            if (opponentName.CurrentRating - rating < 1)
            {
                opponentName.CurrentRating = 1;
            }
            else
            {
                opponentName.CurrentRating -= rating;
            }





        }
        public void LoseGame(GameAccount opponentName, int rating)
        {


            opponentName.CurrentRating += rating;

            if (CurrentRating - rating < 1)
            {
                CurrentRating = 1;

            }
            else
            {
                CurrentRating -= rating;
            }




        }

        public void GetStatus()
        {
            Console.WriteLine("История игор для игрока  "+UserName);
            string status;
            foreach (var game in historyGames)
            {
                if (game.status)
                {
                    status = " выграл";
                }
                else
                {
                    status = " проиграл";
                }
                Console.WriteLine("В игре с индексом " + game.index + " игрок  " + UserName + status + " на " + game.raiting + " очков/ка " + " у игрока " + game.enemy.UserName +
                                  "\n");

            }


        }


    }
    class MainClass
    {
        public static void Main(string[] arg)
        {
            GameAccount player1 = new GameAccount("player1");
            GameAccount player2 = new GameAccount("player2");
            GameAccount player3 = new GameAccount("player3");
            player1.playGame(player2, 10);
            player2.playGame(player1, 100);
            player2.playGame(player1, 10);
            player3.playGame(player1, 20);
            player1.GetStatus();
            player2.GetStatus();
            player3.GetStatus();

        }
    }
}
 
