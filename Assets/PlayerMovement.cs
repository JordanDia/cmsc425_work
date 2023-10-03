using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    CharacterController characterController;


    // Stamina
    public UnityEngine.UI.Image staminaBar;
    public float stamina, maxStamina;

    public float runCost;
    public float chargeAmount;

    private Coroutine recharge;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        if (x != 0 || z != 0)
        {
            stamina -= runCost * Time.deltaTime;
            staminaBar.fillAmount = stamina / maxStamina;
            if (stamina <= 0)
                stamina = 0;

            
            if (recharge != null)
                StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());
        }
        if (stamina != 0)
            characterController.Move(new Vector3(x, 0, z));
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while(stamina < maxStamina)
        {
            stamina += chargeAmount / 10f;
            if (stamina >= maxStamina)
                stamina = maxStamina;
            staminaBar.fillAmount = stamina / maxStamina;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
