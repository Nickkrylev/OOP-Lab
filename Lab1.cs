
using System;

namespace ProjectOne
{
  

    public class Game
    {
        public GameAccount gamer;
        public GameAccount oponent;
        public int raiting;
        public Boolean status;
        public  static int id = 0;
        public int index;

        public Game(GameAccount gamer, GameAccount oponent, int raiting, Boolean status)
        {
            this.gamer = gamer;
            this.oponent = oponent;
            this.raiting = raiting;
            this.status = status;
            id++;
           index = id;
        }

    }
    public class GameAccount
    {
        public string UserName;

        public int CurrentRating;

        public int GamesCount = 0;

        private List<Game> historyGames = new List<Game>();

        public GameAccount(string UserName)
        {
            this.UserName = UserName;
            this.CurrentRating = 1;
           

        }
    
        public void Game(GameAccount opponentName, int rating)
        {
            if (rating <= 0)
            {
                Console.WriteLine("Рейтинг должен быть больше 0");
                do {
                    Console.WriteLine("Введите число больше 0");
                    rating = Int32.Parse(Console.ReadLine()); 
                }while (rating <= 0);
               
            }
            Random random = new Random();
            Boolean statusWin = random.Next(0,1)==1;
            if (statusWin) {
                WinGame(opponentName, rating);
            }else
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
            Console.WriteLine("История игор" );
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
                Console.WriteLine("В игре с индексом " + game.index + " игрок  "+ UserName +status + " на " + game.raiting+ " очков/ка " + " у игрока " + game.oponent.UserName +
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
      
            player1.Game(player2, 2);
            player2.Game(player1, 100);
            player1.GetStatus();
            player2.GetStatus();
        
        }
    }
}
