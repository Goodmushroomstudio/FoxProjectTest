using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    Vector3 spawn;
    public Vector3 nextRoom;
    public int roomNumber;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        spawn = transform.GetChild(0).transform.position;
        if (roomNumber == 0)
        {
            player.transform.position = spawn;
        }
        if (roomNumber < GameData.gd.i_roomCount - 1)
        {
            nextRoom = GameObject.Find("room" + (roomNumber + 1).ToString()).transform.GetChild(0).transform.position;
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
