using UnityEngine;
using System.Collections;

public class RedVicLosTxt : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "";
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void SetWinTxt()
    {
        GetComponent<TextMesh>().text = "YOU WIN";
    }

    void SetLosTxt()
    {
        GetComponent<TextMesh>().text = "YOU LOSE";
    }
}
