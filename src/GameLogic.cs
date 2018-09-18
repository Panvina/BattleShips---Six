
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;
using System.Runtime.ExceptionServices;
using System.Security;

static class GameLogic
{
    [HandleProcessCorruptedStateExceptions]
    [SecurityCritical]
    public static int Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

		SwinGame.PlayMusic(GameResources.GameMusic("Background"));

		//Game Loop
		do {
			GameController.HandleUserInput();
			GameController.DrawScreen();
		} while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

        //Free Resources and Close Audio, to end the program.
        try {
            GameResources.FreeResources();
        } catch (Exception e)
        {
            System.Console.WriteLine("The following exception is due to .NET 4+");
            System.Console.WriteLine(e.Message);
            return 1;
        }

        return 0;
	}
}