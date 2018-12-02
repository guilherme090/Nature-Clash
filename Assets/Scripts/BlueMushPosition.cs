using UnityEngine;
using System.Collections;

public class BlueMushPosition : MonoBehaviour {
    public GameObject BlueMush;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = BlueMush.transform.position + new Vector3 (0.0f, 0.01f ,0.0f);
        transform.eulerAngles = new Vector3(90.0f, BlueMush.transform.eulerAngles.y, 0.0f);
	}
}
