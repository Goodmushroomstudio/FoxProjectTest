using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour {

    Image joystickSprite;
    GameObject stick;
	// Use this for initialization
	void Start () {
        joystickSprite = GetComponent<Image>();
        stick = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.touchCount == 1)
        {
            if (Input.mousePosition.x < Screen.width / 2 && Input.touches[0].phase == TouchPhase.Began)
            {
                transform.position = Input.mousePosition;
                joystickSprite.enabled = true;
                stick.SetActive(true);
            }
            if (joystickSprite.enabled && Input.mousePosition.x < Screen.width / 2)
            {
                Vector2 magn = Input.mousePosition - joystickSprite.gameObject.transform.position; //вычисляем магнитуду между местом касания и текущей точкой курсора
                stick.transform.position = Input.mousePosition;// присваиваем джойстику положение мыши
                Vector2 newPoint = Vector2.ClampMagnitude(magn, 20f); // проверяем что бы длина магнитуды была не более указанного значения (20f...30f) Если более, возвращаем точку в которой магнитуда максимальная
                stick.transform.localPosition = newPoint;
                GameData.gd.AxisX = stick.transform.localPosition.x / 20;
                GameData.gd.AxisY = stick.transform.localPosition.y / 20;
            }
        }
        else
        {
            joystickSprite.enabled = false;
            stick.SetActive(false);
            GameData.gd.AxisX = 0;
            GameData.gd.AxisY = 0;
        }

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            GameData.gd.AxisX = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameData.gd.AxisX = 1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            GameData.gd.AxisX = 0;
        } */
    }
}
