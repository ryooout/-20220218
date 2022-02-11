using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{

   public float Rotate = 4;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0,Rotate,0);
    }
}
