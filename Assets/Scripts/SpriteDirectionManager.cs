using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirectionManager : MonoBehaviour
{
    Vector3 relativePlayerPos;
    float newRelativePlayerPos;
    GameObject player;
    Camera cam;
    float angle;

    //Animation
    Animator animator;
    string currentState;

    //Animation Constants
    const string NORTH = "North";
    const string NEAST = "NEast";
    const string EAST = "East";
    const string SEAST = "SEast";
    const string SOUTH = "South";
    const string SWEST = "SWest";
    const string WEST = "West";
    const string NWEST = "NWest";


    void Start()
    {
        player = GameObject.Find("Player");
        cam = Camera.main;
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {

        GetAngleToPlayer();
        WhichSpriteIsNeeded();

    }

    void GetAngleToPlayer()
    {
        var dir = player.transform.position - transform.parent.position;
        dir.y = 0;
        angle = Vector3.SignedAngle(dir, transform.parent.forward, Vector3.up);

        //Debug.Log(angle);
    }

    void WhichSpriteIsNeeded()
    {
        if ((angle < 22.5f) && (angle > -22.5f))
        {
            ChangeState(SOUTH);
        }
        else if ((angle > 22.5f) && (angle < 67.5f))
        {
            ChangeState(SEAST);
        }
        else if ((angle > 67.5f) && (angle < 112.5f))
        {
            ChangeState(EAST);
        }
        else if ((angle > 112.5f) && (angle < 157.5f))
        {
            ChangeState(NEAST);
        }
        else if ((angle < -22.5f) && (angle > -67.5f))
        {
            ChangeState(SWEST);
        }
        else if ((angle < -67.5f) && (angle > -112.5f))
        {
            ChangeState(WEST);
        }
        else if ((angle < -112.5f) && (angle > -157.5f))
        {
            ChangeState(NWEST);
        }
        else
        {
            ChangeState(NORTH);
        }
    }


    void ChangeState(string newState)
    {
        if (newState == currentState)
            return;

        animator.Play(newState);

        currentState = newState;
    }
}
