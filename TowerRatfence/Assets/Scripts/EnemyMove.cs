using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //Movement
    private int speed = 2;
    private bool blocked = false;

    //Spawning
    private float spawn;
    private float[] spawns = {-0.85f, 0.13f, 1.13f, 2.13f, 3.13f};
    public GameObject Rat;
    private GameObject manager;

    //Animation Player
    Animator anim;
    string currentState;
    const string PLAYER_IDLE = "idle";
    const string PLAYER_JUMP = "jump";
    const string PLAYER_MOVE = "move forward";
    const string PLAYER_FLIP = "flip";

    private void Awake()
    {
        manager = GameObject.Find("GritManager");

        anim = gameObject.GetComponent<Animator>();

        //where spawn, spawn good!
        spawn = spawns[Random.Range(0, 5)];
        transform.position = new Vector3(20, spawn, 0);
    }

    //changes the animation
    private void ChangeAnimationState(string newState)
    {
        if (newState == currentState)
        {
            return;
        }

        anim.Play(newState);
        currentState = newState;
    }


    void Update()
    {
        //moves enemy forward + animation
        if (blocked == false)
        {
            transform.position += new Vector3(-speed, 0) * Time.deltaTime;
            ChangeAnimationState(PLAYER_MOVE);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Tower"))
        {
            blocked = true;
            ChangeAnimationState(PLAYER_IDLE);
        }
        if (col.gameObject.CompareTag("Respawn"))
        {
            manager.GetComponent<RatSpawn>().ReRat(this.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Tower"))
        {
            blocked = false;
            ChangeAnimationState(PLAYER_MOVE);
        }
    }
}
