using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2.0f;
    Vector3 stepVector;
    private float moveHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        stepVector = speed * Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        //stepVector = new Vector3(-moveHorizontal, 0, 0);
        //transform.position += stepVector * speed * Time.deltaTime;
        transform.Translate(stepVector * -moveHorizontal*Time.deltaTime);
    }
}
