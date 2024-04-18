using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Enemy_AImoveAmount;
    Rigidbody Enemy_AIRigidbody;
    Transform tr_Player;
    public LayerMask groundedMask;
    float f_RotSpeed=60.0f,f_MoveSpeed = 40.0f;
    public float walkSpeed = 40;
   
    // Use this for initialization
    void Start () {
       
        tr_Player = GameObject.FindGameObjectWithTag ("Player").transform; }
       
       
    // Update is called once per frame
    void Update () {
        /* Look at Player*/
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
       
        /* Move at Player*/
        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
         }
    void FixedUpdate() {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(Enemy_AImoveAmount) * Time.fixedDeltaTime;
        GetComponent<Rigidbody>();Enemy_AIRigidbody.MovePosition(GetComponent<Rigidbody>().position + localMove);
    }
}

