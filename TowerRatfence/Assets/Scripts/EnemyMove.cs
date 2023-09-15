using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float spawn;
    private int speed = 2;
    private bool blocked = false;
    private float[] spawns = {-5f, -3.5f, -2f, -0.5f, 1f};

    //Animation Player
    Animator anim;
    string currentState;
    const string PLAYER_IDLE = "idle";
    const string PLAYER_JUMP = "jump";
    const string PLAYER_MOVE = "move forward";
    const string PLAYER_FLIP = "flip";

    [SerializeField]
    private GameObject rattricha;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        Debug.Log(spawns.Length);
        //where spawn, spawn good!
        spawn = spawns[Random.Range(0, 5)];
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
        if (col.gameObject.CompareTag("Tower"))
        {
            blocked = true;
            ChangeAnimationState(PLAYER_IDLE);
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
