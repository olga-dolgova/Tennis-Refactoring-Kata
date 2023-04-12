namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int scorePlayer1 = 0;
        private int scorePlayer2 = 0;
        private string player1Name;
        private string player2Name;

        private const int GAME_WINNING_POINT = 4;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                scorePlayer1++;
            else
                scorePlayer2++;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (scorePlayer1 == scorePlayer2)
            {
                switch (scorePlayer1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (scorePlayer1 >= GAME_WINNING_POINT || scorePlayer2 >= GAME_WINNING_POINT)
            {
                var scoreDifference = scorePlayer1 - scorePlayer2;
                if (scoreDifference == 1) score = "Advantage player1";
                else if (scoreDifference == -1) score = "Advantage player2";
                else if (scoreDifference >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = scorePlayer1;
                    else { score += "-"; tempScore = scorePlayer2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

