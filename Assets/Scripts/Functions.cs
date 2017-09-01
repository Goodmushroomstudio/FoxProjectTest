using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
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
    public void Attack()
    {
        if (!GameData.gd.b_onTurn)
        {
            player.GetComponent<Animator>().Play("attack");
        }
    
    }
    public void SelectChar(int i)
    {
        GameData.gd.i_currentChar = i;
        SceneManager.LoadScene(1);
    }



}
