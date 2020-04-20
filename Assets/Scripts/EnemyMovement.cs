using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float sensorRadius = 1f;

    private float currentSpeed;
    private int previousColliderLength = 0;
    private bool isMoving = true;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Fire").transform;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Vector2.Distance(transform.position, target.position) > 0.75f){
            transform.position = Vector2.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
            Collider2D[] col =  Physics2D.OverlapCircleAll(transform.position, sensorRadius);
            if(col.Length > 0 && (col.Length != previousColliderLength)){
                isMoving = !isMoving;
                if(isMoving){
                    currentSpeed = speed;
                }else{
                    currentSpeed = 0;
                }
            }
                previousColliderLength = col.Length;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sensorRadius); 
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Destroy(this.gameObject);
        }
    }

    // void OnTriggerExit2D(Collider2D other){
    //             Debug.Log("Exited");

    //     if(other.tag == "LightCone"){
    //                 Debug.Log("Exited right one");

    //         currentSpeed = speed;
    //     }
    // }
}
