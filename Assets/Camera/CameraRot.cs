using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    public bool moveKeysRotate = false;
    public string bind = "Fire2";
    public float mouseCameraSensitivity = 2.0f;
    public float horizontalAngle = 45f;
    public float verticalAngle = 5f;
    float azimuthal;
    float polar;
    // Why are these initiated at 2.0f? Is this the mouse sens?
    // May want to change to parameter that is adjustable in unity
    float aziSpeed; 
    float polSpeed;
    public float lowestAngle = 2.5f;
    public float highestAngle = 60f;
    
    // Start is called before the first frame update
    void Start()
    {        
        // Fun angle stuff
        lowestAngle = 360f - lowestAngle;
        highestAngle = 360f - highestAngle;
        verticalAngle = - verticalAngle;
        aziSpeed = mouseCameraSensitivity;
        polSpeed = mouseCameraSensitivity;
        azimuthal = horizontalAngle;
        polar = verticalAngle;
    }

    // private void UpdateRotation(float polar, float azimuth) {
    //     if (polar > lowestAngle) {
    //             polar = lowestAngle;
    //     } else if (polar < highestAngle) {
    //         polar = highestAngle;
    //     }
    //     transform.rotation = Quaternion.Euler(-polar, azimuthal, 0);
    // }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(bind) || Input.GetButton(bind)) {
            if (Input.GetButtonDown(bind)) {
                Cursor.lockState = CursorLockMode.Locked;
            }
            float a = aziSpeed * Input.GetAxis("Mouse X");
            float p = polSpeed * Input.GetAxis("Mouse Y");

            azimuthal = ((azimuthal + a) % 360 + 360) % 360;
            polar = ((polar + p) % 360 + 360) % 360;
            if (polar > lowestAngle) {
                polar = lowestAngle;
            } else if (polar < highestAngle) {
                polar = highestAngle;
            }
            transform.rotation = Quaternion.Euler(-polar, azimuthal, 0);
        } else if (Input.GetButtonUp(bind)) {
            Cursor.lockState = CursorLockMode.None;
        } else if (moveKeysRotate) {
            // Should this be moved out of Update to somewhere else?
            float a = aziSpeed * Input.GetAxis("Horizontal") / 10f;
            float p = polSpeed * Input.GetAxis("Vertical") / 10f;
            azimuthal = ((azimuthal + a) % 360 + 360) % 360;
            polar = ((polar + p) % 360 + 360) % 360;
            if (polar > lowestAngle) {
                polar = lowestAngle;
            } else if (polar < highestAngle) {
                polar = highestAngle;
            }
            transform.rotation = Quaternion.Euler(-polar, azimuthal, 0);
        }
        
        //TODO: add rotation lock at ground level or maybe stop camera movement on colliding with ground?
    }
}
