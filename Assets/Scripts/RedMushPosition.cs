using UnityEngine;
using System.Collections;

public class RedMushPosition : MonoBehaviour {
    public GameObject RedMush;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = RedMush.transform.position + new Vector3 (0.0f, 0.01f ,0.0f);
        transform.eulerAngles = new Vector3(90.0f, RedMush.transform.eulerAngles.y, 0.0f);
    }
}
