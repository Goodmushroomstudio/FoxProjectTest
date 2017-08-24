using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
    public static GameData gd = new GameData();
    public float f_axisX, f_axisY; // в Joystick
    public bool b_onGround, b_onTurn; // в Control
    public GameData()
    {
        f_axisX = 0;
        f_axisY = 0;
        b_onGround = false;
        b_onTurn = false;
    }
}
