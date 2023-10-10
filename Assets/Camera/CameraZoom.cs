using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public string zoomOutBind = "=";
    public string zoomInBind = "-";
    public float minZoom = 1f;
    public float maxZoom = 10f;
    public bool mouseWheelZooms;
    public float distance = 6f;
    public float stepSize = .01f;
    Vector3 normalVector;
    // Start is called before the first frame update
    void Start()
    {
        normalVector = this.transform.localPosition.normalized;
        this.transform.localPosition = normalVector * distance;
    }
    private void UpdateZoom(bool zoomOut) {
        distance = distance + (zoomOut ? +1 : -1) * stepSize;
        if (distance < minZoom) {
            distance = minZoom;
        } else if (distance > maxZoom) {
            distance = maxZoom;
        }
        normalVector = this.transform.localPosition.normalized;
        this.transform.localPosition = normalVector * distance;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(zoomInBind) || Input.GetKeyDown(zoomInBind)) {
            UpdateZoom(false);
        } else if (Input.GetKey(zoomOutBind) || Input.GetKeyDown(zoomOutBind)) {
            UpdateZoom(true);
        } else if (mouseWheelZooms) {
            float mWheelInput = Input.GetAxis("Mouse ScrollWheel");
            if (mWheelInput > 0) {
                UpdateZoom(false);
            } else if (mWheelInput < 0) {
                UpdateZoom(true);
            }
        }
    }
}
