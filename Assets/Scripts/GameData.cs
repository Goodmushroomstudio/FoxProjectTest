using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
    public static GameData gd = new GameData();
    public float AxisX, AxisY; // в Joystick
    public GameData()
    {
        AxisX = 0;
        AxisY = 0;
    }
}
