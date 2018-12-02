using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlueMushController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;

    private float upMovement;
    public int HP;
    public GameObject playerText;
    Animator anim;
    public GameObject enemy;  //reference to the Red Mushroom
    public GameObject playerWinLosTxt;
    public GameObject enemyWinLosTxt;
    public GameObject enemyAnimation1;
    public GameObject enemyAnimation2;
    public GameObject enemyWinSound;

    //Hash map the "attacking" string so that the program doesn't need to compare strings all the time
    int attackHash = Animator.StringToHash("Attacking");

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HP = 2000;
        upMovement = 0.0f;
        anim = GetComponent<Animator>();
        //sort a starting position
        transform.position = new Vector3(Random.Range(-30.0F, 30.0F), 0, Random.Range(-30.0F, 30.0F));
    }

    void FixedUpdate()      //This is where Physics calculations take place
    {
        playerText.SendMessage("ShowHP", HP);
        //Check if HP>0. In case it is not, it cannot move.
        if (HP <= 0)
        {
            enemy.SendMessage("AnimateWin");    //the enemy celebrates victory
            enemyAnimation1.SendMessage("SetAnimWin");
            enemyAnimation2.SendMessage("SetAnimWin");
            enemyWinSound.SendMessage("SetAnimWin");
            //Shows victory/loss texts
            enemyWinLosTxt.SendMessage("SetWinTxt");
            playerWinLosTxt.SendMessage("SetLosTxt");
            anim.SetBool("Walking", false);     //stop walking
            rb.isKinematic = true;  //Uncomment this line if physical forces are enabled and they should not for dead characters
        }

        else
        {
            //Blue Mushroom movement (IJKL keys)

            if (Input.GetKey("a"))
            {
                transform.Rotate(0, -1.0f, 0);
            }

            else if (Input.GetKey("d"))
            {
                transform.Rotate(0, 1.0f, 0);
            }

            float moveForward = 0.0f;
            if (Input.GetKey("w"))
            {
                moveForward = 20.0f;
            }
            else if (Input.GetKey("s"))
            {
                moveForward = -20.0f;
            }
            
            //Set animation for walking
            if (moveForward != 0)
            {
                anim.SetBool("Walking", true);
            }

            else
            {
                anim.SetBool("Walking", false);
            }
            
            /*        NOT USING JUMPS FOR NOW.
                        if (gameObject.transform.position.y <= 5.0f)
                    {
                        upMovement = Input.GetKey("space") ? 2.5f : 0.0f;
                    }
            */

            float theta = transform.eulerAngles.y * (Mathf.PI / 180.0f);
            float moveHorizontal = Mathf.Cos(theta) * moveForward;
            float moveVertical = Mathf.Sin(theta) * moveForward;

            Vector3 movement = new Vector3(moveVertical, upMovement, moveHorizontal);
            rb.AddForce(movement * speed);
            //upMovement = 0.0f;

            //In case the mushroom falls, player should press space to make it stand again.
            if (Input.GetKey("space"))
            {
                transform.eulerAngles = new Vector3(0, transform.rotation.y, 0);
            }

        }
    }

    void DealDamage(int attackPower)
    {
        HP -= attackPower;
    }

    void AnimateAttack()
    {
        anim.SetTrigger(attackHash);
    }

    void AnimateWin()
    {
        if (HP > 0)
        {
            rb.isKinematic = true;
            anim.SetBool("Winner", true);
        }
    }
}