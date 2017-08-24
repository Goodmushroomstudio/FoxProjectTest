using UnityEngine;
using System.Collections;

public class controlp2 : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float up, speed;
    bool jump;
    public float speedMin, speedMax;
    GameObject focus;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        focus = transform.GetChild(1).gameObject;
    }

    void FixedUpdate()
    {

        if (GameData.gd.AxisY>0.8f && jump)
        {
            rb.AddForce(new Vector2(0, up), ForceMode2D.Impulse);
            jump = false;
            
        }
        if (GameData.gd.AxisX < 0)
        {
            rb.AddForce(new Vector2(speed * GameData.gd.AxisX, 0), ForceMode2D.Impulse);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, speedMin, speedMax), rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (GameData.gd.AxisX > 0)
        {
            rb.AddForce(new Vector2(speed * GameData.gd.AxisX, 0), ForceMode2D.Impulse);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, speedMin, speedMax), rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (GameData.gd.AxisX == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (GameData.gd.AxisX < 0)
        {
            focus.transform.localPosition = new Vector3(GameData.gd.AxisX * 10, focus.transform.localPosition.y); // динамическое изменение точки фокуса для камеры.
        }
        else
        {
            focus.transform.localPosition = new Vector3(GameData.gd.AxisX * -10, focus.transform.localPosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jump = true;
        }
    }
}
