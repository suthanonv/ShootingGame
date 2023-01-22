using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class DashSkill : MonoBehaviour
{
    public KeyCode key;

    public UnityEvent DashOn, DashOff;
    public GameObject DashAlivableFream;

    private float dashCoolCounter;
    public float dashCooldown;
    private float dashCounter;
    public float dashLeagth;
    

    public Text DashCoolDownText;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {

                dashCounter = dashLeagth;
                playSound.instance.PlayDash();
                Walk.Instace.CurrentSpeed *= 3;
                DashOn.Invoke();
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                Walk.Instace.CurrentSpeed = Walk.Instace.walkSpeed;
                dashCoolCounter = dashCooldown;
                DashOff.Invoke();
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
            DashAlivableFream.SetActive(true);
            DashCoolDownText.text = dashCoolCounter.ToString("#.##");
            if (dashCoolCounter <= 0)
            {
                DashAlivableFream.SetActive(false);
            }
        }
        else
        {
            DashAlivableFream.SetActive(false);
        }
    }
}
