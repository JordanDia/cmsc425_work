using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 2.0f;
    Vector3 stepVector;
    private float moveFB;
    // Start is called before the first frame update
    void Start()
    {
        stepVector = speed * Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        moveFB = Input.GetAxis("Vertical");
        //stepVector = new Vector3(0, 0, -moveFB);
        //transform.position += stepVector * speed * Time.deltaTime;
        transform.Translate(stepVector * -moveFB*Time.deltaTime);
    }
}
