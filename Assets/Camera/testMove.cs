using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            transform.rotation =  Quaternion.Lerp( transform.rotation, transform.rotation*Quaternion.Euler(0,90,0), .1f);
            transform.position = transform.position + new Vector3(1,1,1);
        }
    }
}
