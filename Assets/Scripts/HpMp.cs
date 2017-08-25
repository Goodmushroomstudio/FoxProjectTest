using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpMp : MonoBehaviour {
    public float f_hp = 100;
    public float f_sp = 100;
    public Image img_hp;
    public Image img_sp;
    float f_starthp;
    float f_startsp;
    // Use this for initialization
    void Start () {
        f_starthp = f_hp;
        f_startsp = f_sp;
		
	}
	
	// Update is called once per frame
	void Update () {
        //убывание хп
        float f_scalexhp = f_hp / f_starthp;
        f_scalexhp = Mathf.Clamp(f_scalexhp, 0, 1);
        img_hp.transform.localScale = new Vector3(f_scalexhp,img_hp.transform.localScale.y,1);
        //убывание сп
        float f_scalexsp = f_sp / f_startsp;
        f_scalexsp = Mathf.Clamp(f_scalexsp, 0, 1);
        img_sp.transform.localScale = new Vector3(f_scalexsp, img_sp.transform.localScale.y, 1);




        GameData.gd.f_hp = f_hp;
        GameData.gd.f_sp = f_sp;
	}
}
