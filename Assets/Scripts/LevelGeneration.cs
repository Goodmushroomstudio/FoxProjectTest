using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
    public GameObject room;
    public int i_roomcount;

	// Use this for initialization
	void Start () {
        for (int i = 0; i<i_roomcount;i++)
        {
            GameObject newroom = Instantiate(room, new Vector3(i*100,0,0), Quaternion.identity, this.transform);
            newroom.name = "room"+i.ToString();
            if (i != GameData.gd.i_currentRoom)
            {
                newroom.GetComponent<Room>().enabled = false;
            }
        } 

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
