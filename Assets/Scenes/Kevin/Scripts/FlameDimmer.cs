using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDimmer : MonoBehaviour
{
    private Light pointLight;
    private ParticleSystem fireEffect;
    public float durationSec = 20.0f;
    private float dimSpeed;

    // Start is called before the first frame update
    void Start()
    {
        pointLight = GameObject.Find("fireLight").GetComponent<Light>();
        pointLight.intensity = 2;
        pointLight.range = 5;
        dimSpeed = (2.0f/durationSec);
        fireEffect = GameObject.Find("fireEffect").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        pointLight = GameObject.Find("fireLight").GetComponent<Light>();

        if (pointLight.intensity > 0){
            pointLight.intensity -= dimSpeed * Time.deltaTime;
            if (pointLight.intensity < 0) {
                pointLight.intensity = 0;
            }
        }

        if (pointLight.range > 0){
            pointLight.range -= dimSpeed * Time.deltaTime;
            if (pointLight.range < 0) {
                pointLight.range = 0;
            }
            if (pointLight.intensity == 0){
                pointLight.range = 0;
            }
            
        } 
        fireEffect = GameObject.Find("fireEffect").GetComponent<ParticleSystem>();
        var main = fireEffect.main;
        if (main.startSize.constant > 0){
            main.startSize = new ParticleSystem.MinMaxCurve(main.startSize.constant - dimSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space)){
            pointLight.intensity = 2;
            pointLight.range = 5;
            main.startSize = new ParticleSystem.MinMaxCurve(2.0f);
        }
    }
}
