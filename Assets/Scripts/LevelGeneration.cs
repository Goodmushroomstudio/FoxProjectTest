using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
    public GameObject[] rooms;
    public int[] mBossRoomNumbers;
    public int i_roomcount;
    public GameObject[] players;

    void Awake()
    {
        GameObject player = Instantiate(players[GameData.gd.i_currentChar], Vector3.zero, Quaternion.identity);
        player.name = "Player";
    }

	void Start () {
        GameData.gd.i_roomCount = i_roomcount;
        for (int i = 0; i < i_roomcount; i++)
        {
            int r = Random.Range(0, 2);
            GameObject newroom = Instantiate(rooms[r], new Vector3(i*200,0,0), Quaternion.identity, this.transform);
            newroom.name = "room"+i.ToString();
            newroom.GetComponent<Room>().roomNumber = i;
            for (int m = 0; m < mBossRoomNumbers.Length; m++)
            {
                if (i == mBossRoomNumbers[m])
                {
                    newroom.GetComponent<Room>().mBossRoom = true;
                }
            }
            if (i + 1 == i_roomcount)
            {
                newroom.GetComponent<Room>().bossRoom = true;
            }
        }
	}
}
