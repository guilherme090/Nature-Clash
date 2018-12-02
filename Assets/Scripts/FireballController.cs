using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {
    public GameObject player;
    private ParticleSystem emitter;
    private bool isBeingFired = false;
    public int damage;
    private Rigidbody rb;

        // Use this for initialization
        void Start () {
        emitter = GetComponent<ParticleSystem>();
        damage = 200;
        rb = player.GetComponent<Rigidbody>();
        }
	
	    // Update is called once per frame
	    void Update () {
        //effect follows the player everywhere
        transform.position = player.transform.position + new Vector3(0.0f, 0.3f, 0.0f);
        Vector3 newRotation = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
        transform.eulerAngles = newRotation;

        //activate fireball with the press of a button if player is active (HP > 0)

        if (!rb.isKinematic)
        {
            emitter.enableEmission = Input.GetKey("m");
            if (Input.GetKey("m"))
            {
                player.SendMessage("AnimateAttack");
            }
        }
        else
        {
            emitter.enableEmission = false;
        }

       /* 
            if (Input.GetKey("m"))
        {
            emitter.enableEmission = true;
            isBeingFired = true;
            How do I know when the effect is over?
        }
        */
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("BluePlayer"))
        {
            other.SendMessage("DealDamage", damage);
        }
    }
}
