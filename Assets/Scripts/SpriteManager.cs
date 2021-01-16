using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    Vector3 relativePlayerPos;
    GameObject player;

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
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        relativePlayerPos = GetComponentInParent<Transform>().position - player.transform.position;
        relativePlayerPos = Vector3.Normalize(relativePlayerPos);

        Debug.Log(relativePlayerPos);

        FigureOutAnimationState();
    }

    void FigureOutAnimationState()
    {
        if ((relativePlayerPos.x > 0.7) && (relativePlayerPos.z < 0.7))
        {
            if (currentState == NORTH)
            {
                ChangeAnimationState(NEAST);
            }
            else if ((relativePlayerPos.x < 0.7) && (relativePlayerPos.z > 0.7))
            {
                ChangeAnimationState(NORTH);
            }
        }
    }

    void ChangeAnimationState(string newState)
    {
        //Stop Same Animation From Playing Itself
        if (currentState == newState) return;

        //Play Animation
        animator.Play(newState);

        //Reassign Current State
        currentState = newState;
    }
}
