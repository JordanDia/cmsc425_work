using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollwheelZoom : MonoBehaviour
{
    public float zoomSpeed = 10.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 100.0f;
    private Camera meCamera;
    // Start is called before the first frame update
    void Start()
    {
        meCamera = GameObject.Find("Me Camera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float scrolldata;
        scrolldata = Input.GetAxis("Mouse ScrollWheel");
        var targetZoom = meCamera.fieldOfView - scrolldata * zoomSpeed;
        meCamera.fieldOfView = Mathf.Clamp(targetZoom, minZoom, maxZoom);
    }
}
