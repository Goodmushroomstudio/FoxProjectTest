using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    Vector3 spawn;
    public GameObject nextRoom;
    public int roomNumber;
    public bool mBossRoom;
    public bool bossRoom;
    public int localEnemyCount;
    GameObject player;
	// Use this for initialization
	void Start () {

        int r = Random.Range(0, 2);
        player = GameObject.Find("Player");
        spawn = transform.GetChild(0).transform.position;
        if (roomNumber < GameData.gd.i_roomCount - 1)
        {
            nextRoom = GameObject.Find("room" + (roomNumber + 1).ToString()).transform.GetChild(0).gameObject;
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        if (!bossRoom && !mBossRoom)
        {
            transform.GetChild(2).transform.GetChild(r).gameObject.SetActive(true);
            localEnemyCount = 2;
        }
        else if (mBossRoom)
        {
            transform.GetChild(2).transform.GetChild(2).gameObject.SetActive(true);
            localEnemyCount = 1;
        }
        else if (bossRoom)
        {
            transform.GetChild(2).transform.GetChild(3).gameObject.SetActive(true);
            localEnemyCount = 1;
        }
        if (roomNumber == 0)
        {
            player.transform.position = spawn;
            GameData.gd.i_enemyCount = localEnemyCount;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
