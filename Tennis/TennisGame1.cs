namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _scorePlayer1 = 0;
        private int _scorePlayer2 = 0;
        private string _player1Name;
        private string _player2Name;

        private const int GameWinningPoint = 4;

        public TennisGame1(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _scorePlayer1++;
            else
                _scorePlayer2++;
        }

        public string GetScore()
        {
            var score = "";
            if (_scorePlayer1 == _scorePlayer2)
            {
                score = _scorePlayer1 switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };
            }
            else if (_scorePlayer1 >= GameWinningPoint || _scorePlayer2 >= GameWinningPoint)
            {
                var scoreDifference = _scorePlayer1 - _scorePlayer2;
                score = scoreDifference switch
                {
                    1 => "Advantage player1",
                    -1 => "Advantage player2",
                    >= 2 => "Win for player1",
                    _ => "Win for player2"
                };
            }
            else
            {
                var tempScore = 0;
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = _scorePlayer1;
                    else { score += "-"; tempScore = _scorePlayer2; }
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

