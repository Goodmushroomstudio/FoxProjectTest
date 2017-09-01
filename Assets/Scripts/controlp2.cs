using UnityEngine;
using System.Collections;

public class controlp2 : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float up, speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (GameData.gd.f_axisY>0.95f && GameData.gd.b_onGround && !GameData.gd.b_onTurn)
        {
            GameData.gd.f_currentsp -= 10;
            rb.AddForce(new Vector2(0, up), ForceMode2D.Impulse);
            GameData.gd.b_onGround = false;  
        }
        if (GameData.gd.f_axisY < -0.95f && GameData.gd.b_onGround && !GameData.gd.b_onTurn)
        {
            GameData.gd.b_onTurn = true;
            GetComponent<Animator>().Play("turn");
            GameData.gd.f_currentsp -= 20;
        }
        if (GameData.gd.f_axisX != 0 && !GameData.gd.b_onTurn)
        {
            transform.Translate(new Vector3((GameData.gd.f_axisX*speed)*Time.deltaTime,0));    
            if (GameData.gd.f_axisX > 0 && !GameData.gd.b_onTurn)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (GameData.gd.b_onTurn)
        {
            if (GameData.gd.f_axisX > 0)
            {
                transform.Translate(new Vector3(15*Time.deltaTime,0,0));
            }
            if (GameData.gd.f_axisX < 0)
            {
                transform.Translate(new Vector3(-15*Time.deltaTime,0,0));
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            GameData.gd.b_onGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("portal") && GameData.gd.i_enemyCount == 0)
        {
            transform.position = collision.gameObject.transform.parent.GetComponent<Room>().nextRoom.transform.position;
            GameData.gd.i_enemyCount = collision.gameObject.transform.parent.GetComponent<Room>().nextRoom.transform.parent.GetComponent<Room>().localEnemyCount;
        }
    }
}
