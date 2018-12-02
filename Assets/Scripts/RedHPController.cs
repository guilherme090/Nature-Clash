using UnityEngine;
using System.Collections;

public class RedHPController : MonoBehaviour {
  
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowHP(int hp)
    {
        if (hp <= 0)
        {
            GetComponent<TextMesh>().text = "HP = 0";
        }
        else
        {
            GetComponent<TextMesh>().text = "HP = " + hp.ToString();
        }     
    }
}
