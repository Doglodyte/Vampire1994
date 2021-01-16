using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    Vector3 relativePlayerPos;
    float newRelativePlayerPos;
    GameObject player;
    Camera cam;

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

        AnimState5();

    }

    void AnimState5()
    {
        var dir = player.transform.position - transform.parent.position;
        dir.y = 0;
        var angle = Vector3.SignedAngle(dir, transform.parent.forward, Vector3.up);

        Debug.Log(angle);
    }


    void AnimState4()
    {
        relativePlayerPos = GetComponentInParent<Transform>().position - player.transform.position;
        relativePlayerPos = Vector3.Normalize(relativePlayerPos);

        animator.SetFloat("playerX", relativePlayerPos.x);
        animator.SetFloat("playerZ", relativePlayerPos.z);

        //Debug.Log(relativePlayerPos);
    }


    void NewFigureOutAnimationState()
    {
        //Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 forward = new Vector3(1, 0, 0);
        forward = Vector3.Normalize(forward);
        Vector3 toOther = player.transform.position - transform.position;
        toOther = Vector3.Normalize(toOther);
        newRelativePlayerPos = Vector3.Dot(forward, toOther);
        //newRelativePlayerPos = newRelativePlayerPos * 360;

        Debug.Log(newRelativePlayerPos);
    }
}
