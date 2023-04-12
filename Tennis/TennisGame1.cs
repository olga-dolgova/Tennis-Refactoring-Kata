namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int matchScorePlayer1 = 0;
        private int matchScorePlayer2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                matchScorePlayer1 += 1;
            else
                matchScorePlayer2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (matchScorePlayer1 == matchScorePlayer2)
            {
                switch (matchScorePlayer1)
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
            else if (matchScorePlayer1 >= 4 || matchScorePlayer2 >= 4)
            {
                var minusResult = matchScorePlayer1 - matchScorePlayer2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = matchScorePlayer1;
                    else { score += "-"; tempScore = matchScorePlayer2; }
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

