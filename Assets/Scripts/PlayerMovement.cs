using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float dashCooldown = 2.5f;
    public float dashSpeed = 40f;
    public float dashDuration = 1f;

    private float currentSpeed;
    private float dashCooldownTime;
    private float dashTime = 0;
    private bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
        dashCooldownTime = dashCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

    if(isDashing){
            if(dashTime <= 0){
                isDashing = false;
                currentSpeed = speed;

            }else{
                dashTime -= Time.deltaTime;
            }
    }else{
        if(dashCooldownTime <= 0){
            if(Input.GetKeyDown("space")){
                currentSpeed = dashSpeed;
                isDashing = true;
                dashTime = dashDuration;
                dashCooldownTime = dashCooldown;
            }
        }else{
            dashCooldownTime -= Time.deltaTime;
        }
    }


        Vector3 movement = new Vector3(xMov, yMov, 0f).normalized * currentSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
