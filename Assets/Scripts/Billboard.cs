using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera cam;
    Transform camLocation;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }


    void Update()
    {
        camLocation = cam.transform;
        //var fwd = cam.transform.forward;
        //fwd.y = 0.0f;
        //transform.rotation = Quaternion.LookRotation(fwd);
    }

    void LateUpdate()
    {
       transform.LookAt(camLocation);

       transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
