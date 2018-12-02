using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioSource ambientAudio = GetComponent<AudioSource>();
        ambientAudio.Play();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    void StopAmbientSound()
    {
        AudioSource ambientAudio = GetComponent<AudioSource>();
        ambientAudio.Stop();
    }
}
