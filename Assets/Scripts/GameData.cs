using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData {
    public static GameData gd = new GameData();
    public float f_axisX, f_axisY; // в Joystick
    public bool b_onGround, b_onTurn; // в Control
    public float[] f_hp;
    public float[] f_sp;
    public float f_currenthp;
    public float f_currentsp;// HpSp,Control
    public int i_currentChar;
    public int i_currentRoom;
    public int i_roomCount;
    public int i_enemyCount;
    public GameData()
    {
        i_currentChar = 0;
        f_hp = new float[] { 100, 100 };
        f_sp = new float[] { 100, 100 };
        f_currenthp = 100;
        f_currentsp = 100;
        f_axisX = 0;
        f_axisY = 0;
        b_onGround = false;
        b_onTurn = false;
        i_currentRoom = 0;
        i_roomCount = 0;
        i_enemyCount = 0;
    }
}
