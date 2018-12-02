using UnityEngine;
using System.Collections;

public class WinAnimTrigger : MonoBehaviour {
    private ParticleSystem emitter;
    // Use this for initialization
    void Start () {
        emitter = GetComponent<ParticleSystem>();
        emitter.enableEmission = false;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    void SetAnimWin()
    {
        emitter.enableEmission = true;
    }
}
