using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour {

    Image joystickSprite;
    GameObject stick;
    public float magnMax;
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
                Vector2 newPoint = Vector2.ClampMagnitude(magn, magnMax); // проверяем что бы длина магнитуды была не более указанного значения (20f...30f) Если более, возвращаем точку в которой магнитуда максимальная
                stick.transform.localPosition = newPoint;
                GameData.gd.f_axisX = stick.transform.localPosition.x / magnMax;
                GameData.gd.f_axisY = stick.transform.localPosition.y / magnMax;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (joystickSprite.enabled && Input.mousePosition.x < Screen.width / 2)
            {
                GameData.gd.f_axisX = stick.transform.localPosition.x / magnMax;
                GameData.gd.f_axisY = stick.transform.localPosition.y / magnMax;
            }
        }
        else
        {
            joystickSprite.enabled = false;
            stick.SetActive(false);
            GameData.gd.f_axisX = 0;
            GameData.gd.f_axisY = 0;
        }

    }

    void Update()
    {
        if (Input.mousePosition.x < Screen.width / 2 && Input.GetMouseButtonDown(0))
        {
            transform.position = Input.mousePosition;
            joystickSprite.enabled = true;
            stick.transform.localPosition = Input.mousePosition;
            stick.SetActive(true);
        }
        stick.transform.position = Input.mousePosition;// присваиваем джойстику положение мыши
        Vector2 magn = Input.mousePosition - joystickSprite.gameObject.transform.position; //вычисляем магнитуду между местом касания и текущей точкой курсора
        Vector2 newPoint = Vector2.ClampMagnitude(magn, magnMax); // проверяем что бы длина магнитуды была не более указанного значения (20f...30f) Если более, возвращаем точку в которой магнитуда максимальная
        stick.transform.localPosition = newPoint;
    }
}
