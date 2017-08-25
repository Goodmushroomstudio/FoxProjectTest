using UnityEngine;
using System.Collections;

public class controlp2 : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float up, speed;
    public float speedMin, speedMax;
    GameObject focus;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        focus = transform.GetChild(1).gameObject;
    }

    void FixedUpdate()
    {

        if (GameData.gd.f_axisY>0.95f && GameData.gd.b_onGround)
        {
            GameData.gd.f_currentsp -= 10;
            rb.AddForce(new Vector2(0, up), ForceMode2D.Impulse);
            GameData.gd.b_onGround = false;  
        }
        if (GameData.gd.f_axisY < -0.95f && GameData.gd.b_onGround)
        {
            GameData.gd.b_onTurn = true;
        }
        if (GameData.gd.f_axisX < 0)
        {
            rb.AddForce(new Vector2(speed * GameData.gd.f_axisX, 0), ForceMode2D.Impulse);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, speedMin, speedMax), rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (GameData.gd.f_axisX > 0)
        {
            rb.AddForce(new Vector2(speed * GameData.gd.f_axisX, 0), ForceMode2D.Impulse);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, speedMin, speedMax), rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (GameData.gd.f_axisX == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (GameData.gd.f_axisX < 0)
        {
            focus.transform.localPosition = new Vector3(GameData.gd.f_axisX * 10, focus.transform.localPosition.y); // динамическое изменение точки фокуса для камеры.
        }
        else
        {
            focus.transform.localPosition = new Vector3(GameData.gd.f_axisX * -10, focus.transform.localPosition.y);
        }

        if (GameData.gd.b_onTurn)
        {
            if (transform.GetChild(0).transform.rotation.z >= 360)
            {
                transform.GetChild(0).transform.rotation.Set(0,0,0,0);
                GameData.gd.b_onTurn = false;
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

}
