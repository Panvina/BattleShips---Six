
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
/// <summary>
/// The result of an attack.
/// </summary>
namespace Battleships
{
    public enum ResultOfAttack
    {
        /// <summary>
        /// The player hit something
        /// </summary>
        Hit,

        /// <summary>
        /// The player missed
        /// </summary>
        Miss,

        /// <summary>
        /// The player destroyed a ship
        /// </summary>
        Destroyed,

        /// <summary>
        /// That location was already shot.
        /// </summary>
        ShotAlready,

        /// <summary>
        /// The player killed all of the opponents ships
        /// </summary>
        GameOver
    }
}
//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
