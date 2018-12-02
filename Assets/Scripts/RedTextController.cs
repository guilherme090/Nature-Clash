using UnityEngine;
using System.Collections;

public class RedTextController : MonoBehaviour {
    public GameObject RedMush;
    const float MUSHROOM_HEIGHT = 0.7f;

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "";
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = RedMush.transform.position + new Vector3(0.0f, MUSHROOM_HEIGHT, 0.0f);
        transform.rotation = RedMush.transform.rotation;
    }

    /* NOT SHOWING DAMAGE FOR NOW, SINCE WE ALREADY SHOW THE HP
    void ShowDamage (int damage)
    {
            GetComponent<TextMesh>().text = damage.ToString();
        //Display damage value
            transform.position = transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        //Wait for 2 seconds until erasing the damage value.
            while Wait(2);
            GetComponent<TextMesh>().text = "";
    }

    IEnumerator Wait(float duration)
    {
        //This is a coroutine
        yield return new WaitForSeconds(duration);   //Wait
    }
    */
    
}
