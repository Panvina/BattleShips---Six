
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;

/// <summary>
/// The EndingGameController is responsible for managing the interactions at the end
/// of a game.
/// </summary>

static class EndingGameController
{

	/// <summary>
	/// Draw the end of the game screen, shows the win/lose state
	/// </summary>
    /// <remarks>
    /// Isuru: Updated to new swingame call
    /// </remarks>
	public static void DrawEndOfGame()
	{
		UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
		UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

		Rectangle toDraw = new Rectangle ();
		toDraw.X = 0;
		toDraw.Y = 250;
		toDraw.Width = SwinGame.ScreenWidth ();
		toDraw.Height = SwinGame.ScreenHeight ();
        String whatShouldIPrint = "I have long variable names";
		if (GameController.HumanPlayer.IsDestroyed) {
            whatShouldIPrint = "YOU LOSE!";
        } else {
			whatShouldIPrint = "-- WINNER --";
		}
        SwinGame.DrawText (whatShouldIPrint, Color.White, Color.Transparent,GameResources.GameFont ("ArialLarge"),FontAlignment.AlignCenter, toDraw);
	}

	/// <summary>
	/// Handle the input during the end of the game. Any interaction
	/// will result in it reading in the highsSwinGame.
	/// </summary>
    /// <remarks>
    /// Isuru: Updated keycodes
    /// </remarks>
	public static void HandleEndOfGameInput()
	{
        if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.ReturnKey) || SwinGame.KeyTyped(KeyCode.EscapeKey)) {
			HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
			GameController.EndCurrentState();
		}
	}

}
