using static Tennis.TennisGame2.TennisGame2;
using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _scorePlayer1 = 0;
        private int _scorePlayer2 = 0;
        private string _namePlayer1;
        private string _namePlayer2;

        private const int GameWinningPoint = 4;

        public enum TennisScores
        {
            Love = 0,
            Fifteen = 1,
            Thirty = 2,
            Forty = 3
        }

        public TennisGame1(string namePlayer1, string namePlayer2)
        {
            this._namePlayer1 = namePlayer1;
            this._namePlayer2 = namePlayer2;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == this._namePlayer1)
                _scorePlayer1++;
            else
                _scorePlayer2++;
        }

        public string GetScore()
        {
            if (IsGameTied())
            {
                return GetScoreWhenGameIsTied();
            }
            else if (_scorePlayer1 >= GameWinningPoint || _scorePlayer2 >= GameWinningPoint)
            {
                return GetScoreWhenAdvantageOrWinForOnePlayer();
            }
            return GetScoreBetweenPlayers();
        }

        private bool IsGameTied()
        {
            return _scorePlayer1 == _scorePlayer2;
        }

        private string GetScoreWhenGameIsTied()
        {
            return _scorePlayer1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }

        private string GetScoreWhenAdvantageOrWinForOnePlayer()
        {
            return (_scorePlayer1 - _scorePlayer2) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        }

        private string GetScoreBetweenPlayers()
        {
            return $"{GetNameOfTheScore(_scorePlayer1)}-{GetNameOfTheScore(_scorePlayer2)}";
        }

        private static string GetNameOfTheScore(int score)
        {
            if (!Enum.IsDefined(typeof(TennisPoints), score))
            {
                throw new ArgumentOutOfRangeException(nameof(score));
            }

            return Enum.GetName(typeof(TennisPoints), score);
        }
    }
}

