﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Addhp ()
    {
        GameData.gd.f_currenthp += 10;
    }
    public void damage()
    {
        GameData.gd.f_currenthp -= 10;
    }

    public void TurnOff()
    {
        GameData.gd.b_onTurn = false;
    }
}
