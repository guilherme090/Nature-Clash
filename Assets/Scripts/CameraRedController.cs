using UnityEngine;
using System.Collections;

public class CameraRedController : MonoBehaviour {

    public GameObject RedMushroom;
    const float RADIUS = 1.2f;          //this is the distance from the mushroom to the camera
    const float Y_OFFSET = 1.0f;
    const float DIST_TO_FOCUS = 2.0f;   //this is the point where the camera will look at

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        //get the angle relative to the rotation around y
        float theta = RedMushroom.transform.eulerAngles.y * (Mathf.PI / 180.0f);  
        //put the camera below the player 
        transform.position = RedMushroom.transform.position + new Vector3 ( - Mathf.Sin(theta) * RADIUS, Y_OFFSET , - Mathf.Cos(theta)* RADIUS );

        //Look in the direction of the mushroom's orientation
        //Vector3 newRotation = new Vector3(transform.eulerAngles.x, RedMushroom.transform.eulerAngles.y, transform.eulerAngles.z);
        //transform.eulerAngles = newRotation;

        //Look at the direction of a point in front of the mushroom
        transform.LookAt(RedMushroom.transform.position + new Vector3 ( Mathf.Sin(theta) * DIST_TO_FOCUS, 0, Mathf.Cos(theta) * DIST_TO_FOCUS));
    }
}
