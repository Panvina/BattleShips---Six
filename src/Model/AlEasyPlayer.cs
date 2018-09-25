using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;

/// <summary>
/// ''' EasyAIPlayer is a type of AIPlayer. All shot that are taken are random
/// ''' shot generated with the GenerateCoords
/// ''' </summary>

namespace Battleships
{
    public class AIEasyPlayer : AIPlayer
    {
        public AIEasyPlayer(BattleShipsGame controller) : base(controller)
        {
        }
        private Location _nextLocation;
        /// <summary>
        ///     ''' GenerateCoords generates shots at random location.
        ///     ''' </summary>
        ///     ''' <param name="row">the row it generates</param>
        ///     ''' <param name="column">the column it generates</param>
        protected override void GenerateCoords(ref int row, ref int column)
        {
            do
            {
                if (_nextLocation != null)
                {
                    row = _nextLocation.Row;
                    column = _nextLocation.Column;
                    _nextLocation = null;
                }
                else
                {
                    row = Player._Random.Next(0, EnemyGrid.Height);
                    column = _Random.Next(0, EnemyGrid.Width);
                }
            }
            while ((row < 0 || column < 0 || row >= EnemyGrid.Height || column >= EnemyGrid.Width || EnemyGrid[row, column] != TileView.Sea));
        }

        /// <summary>
        ///     ''' ProcessShot does nothing with the easy AIPlayer because this player
        ///     ''' doesn't know anything beside generating random coordinates
        ///     ''' </summary>
        ///     ''' <param name="row">row it shot at</param>
        ///     ''' <param name="col">the col it shot at</param>
        ///     ''' <param name="result">the result from the last shot</param>
        protected override void ProcessShot(int row, int col, AttackResult result)
        {
            if (result.Value == ResultOfAttack.Hit)
            {
                switch (_Random.Next(4))
                {
                    case 0:
                        _nextLocation = new Location(row + 1, col);
                        break;
                    case 1:
                        _nextLocation = new Location(row - 1, col);
                        break;
                    case 2:
                        _nextLocation = new Location(row, col + 1);
                        break;
                    case 3:
                        _nextLocation = new Location(row, col - 1);
                        break;
                }

                if (_nextLocation.Row < 0)
                    _nextLocation.Row = 0;
                else if (_nextLocation.Row >= PlayerGrid.Height)
                    _nextLocation.Row = PlayerGrid.Height - 1;

                if (_nextLocation.Column < 0)
                    _nextLocation.Column = 0;
                else if (_nextLocation.Column >= PlayerGrid.Width)
                    _nextLocation.Column = PlayerGrid.Width - 1;
            }
        }
    }
}
