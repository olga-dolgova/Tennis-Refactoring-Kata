using System;

namespace Tennis.TennisGame2
{
    public class TennisGame2 : ITennisGame
    {
        public enum TennisPoints
        {
            Love = 0,
            Fifteen = 1,
            Thirty = 2,
            Forty = 3
        }

        private readonly TennisPlayer _player1;
        private readonly TennisPlayer _player2;

        public TennisGame2(string player1Name, string player2Name)
        {
            this._player1 = new TennisPlayer(player1Name);
            this._player2 = new TennisPlayer(player2Name);
        }

        public string GetScore()
        {
            if (IsGameTied())
            {
                return GetTieScoreAsString();
            }

            if (DoesOneOfThePlayersHaveAdvantageOrWin())
            {
                return GetAdvantageOrWinScoreAsString();
            }

            return $"{GetIndividualScore(_player1.Points)}-{GetIndividualScore(_player2.Points)}";
        }

        private bool IsGameTied()
        {
            return _player1.Points == _player2.Points;
        }

        //When both players are tied and have won 3 points each (3 points = score Forty), it is called a deuce in tennis term
        private bool BothPlayersHaveWon3PointsOrMore()
        {
            return _player1.Points >= (int)TennisPoints.Forty && _player2.Points >= (int)TennisPoints.Forty;
        }

        private string GetTieScoreAsString()
        {
            if (BothPlayersHaveWon3PointsOrMore())
            {
                return "Deuce";
            }

            return $"{GetIndividualScore(_player1.Points)}-All";
        }

        private static string GetIndividualScore(int point)
        {
            if (!Enum.IsDefined(typeof(TennisPoints), point))
            {
                throw new ArgumentOutOfRangeException(nameof(point));
            }

            return Enum.GetName(typeof(TennisPoints), point);
        }

        private bool DoesOneOfThePlayersHaveAdvantageOrWin()
        {
            return _player1.IsPlayerPointsDeuceOrMore() || _player2.IsPlayerPointsDeuceOrMore();
        }

        private string GetAdvantageOrWinScoreAsString()
        {
            if (IsOnePlayerLeadingByOnePoint())
            {
                return "Advantage " + (IsPlayer1Leading() ? _player1.Name : _player2.Name);
            }

            return "Win for " + (IsPlayer1Leading() ? _player1.Name : _player2.Name);
        }

        private int GetScoreDifference()
        {
            return _player1.Points - _player2.Points;
        }

        private bool IsPlayer1Leading()
        {
            var scoreDifference = GetScoreDifference();
            return scoreDifference > 0;
        }

        private bool IsOnePlayerLeadingByOnePoint()
        {
            var scoreDifference = GetScoreDifference();
            return Math.Abs(scoreDifference) == 1;
        }

        public void WonPoint(string player)
        {
            if (player == _player1.Name)
            {
                _player1.AddPoint();
            }
            else
            {
                _player2.AddPoint();
            }
        }

    }
}

