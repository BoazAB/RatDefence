using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float rand;
    private float spawn;
    private int speed = 2;
    private bool blocked = false;

    //Animation Player
    Animator anim;
    string currentState;
    const string PLAYER_IDLE = "idle";
    const string PLAYER_JUMP = "jump";
    const string PLAYER_MOVE = "move forward";
    const string PLAYER_FLIP = "flip";


    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();

        //where spawn, spawn good!
        rand = Random.Range(1, 5);
        if (rand == 1)
        {
            spawn = -5f;
        }
        else if (rand == 2)
        {
            spawn = -3.5f;
        }
        else if (rand == 3)
        {
            spawn = -2f;
        }
        else if (rand == 4)
        {
            spawn = -0.5f;
        }
        else if (rand == 5)
        {
            spawn = 1f;
        }
        transform.position = new Vector3(12, spawn, 0);
        transform.RotateAround(transform.position, transform.up, 180f);
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
        if (col.gameObject.tag == "Tower")
        {
            blocked = true;
            ChangeAnimationState(PLAYER_IDLE);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tower")
        {
            blocked = false;
            ChangeAnimationState(PLAYER_MOVE);
        }
    }
}
