using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
    public GameObject room;
    public int i_roomcount;
    public GameObject[] players;

	// Use this for initialization
	void Start () {
        GameData.gd.i_roomCount = i_roomcount;
        Instantiate(players[GameData.gd.i_currentChar], Vector3.zero, Quaternion.identity);
        for (int i = 0; i<i_roomcount;i++)
        {
            GameObject newroom = Instantiate(room, new Vector3(i*100,0,0), Quaternion.identity, this.transform);
            newroom.name = "room"+i.ToString();
            newroom.GetComponent<Room>().roomNumber = i;
        } 

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
