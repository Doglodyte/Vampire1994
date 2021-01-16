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
    const string NWest = "NWest";


    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        relativePlayerPos = GetComponentInParent<Transform>().position - player.transform.position;
        relativePlayerPos = Vector3.Normalize(relativePlayerPos);

        animator.SetFloat("relativePlayerPosX", relativePlayerPos.x);
        animator.SetFloat("relativePlayerPosZ", relativePlayerPos.z);

        Debug.Log(relativePlayerPos);
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
