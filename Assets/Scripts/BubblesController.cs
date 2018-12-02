using UnityEngine;
using System.Collections;

public class BubblesController : MonoBehaviour {
    public GameObject player;
    private ParticleSystem emitter;
    private bool isBeingFired = false;
    public int damage;
    private Rigidbody rb;

        // Use this for initialization
        void Start () {
        emitter = GetComponent<ParticleSystem>();
        damage = 50;
        rb = player.GetComponent<Rigidbody>(); 
        }
	
	    // Update is called once per frame
	    void Update () {
            //effect follows the player everywhere
            transform.position = player.transform.position;
            Vector3 newRotation = new Vector3(transform.eulerAngles.x, player.transform.eulerAngles.y, transform.eulerAngles.z);
            transform.eulerAngles = newRotation;

        //activate bubbles with the press of a button if player is active (HP > 0)

        if (! rb.isKinematic)
        {
            if (Input.GetKey("z"))
            {
                player.SendMessage("AnimateAttack");
            }
            emitter.enableEmission = Input.GetKey("z");
        }
        else
        {
            emitter.enableEmission = false;
        }

        /* 
             if (Input.GetKey("z"))
         {
             emitter.enableEmission = true;
             isBeingFired = true;
             How do I know when the effect is over?
         }
         */

    }

        void OnParticleCollision(GameObject other)
        {
        if (other.CompareTag("RedPlayer"))
            {
            other.SendMessage("DealDamage", damage);    
            //other.SendMessage  DOESNT WORK;
            }
        }
}
