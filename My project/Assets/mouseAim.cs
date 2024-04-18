using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseAim : MonoBehaviour
{
    // Start is called before the first frame update
    /*
    private Camera mainCam; 
    private Vector3 mousePos;
    
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); 

        Vector3 rotation = mousePos -transform.position; 

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; 
        
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    } 

    */
    public float offset;

    private GameObject player;
    private SpriteRenderer spriteren; 

    public GameObject Bullet;
    public Transform ShootPoint;


    public float BulletSpeed;
    public float FireRate;
    float readyForNextShoot;





    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteren = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(rotZ < 89 && rotZ > -89)
        {
            spriteren.flipY = false;
            spriteren.flipX = false;
        }
        else
        {
            spriteren.flipY = true;
            spriteren.flipX = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > readyForNextShoot)
            {
                readyForNextShoot = Time.time + 1 / FireRate;

            }
        }
    }

    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, transform.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);

    }


}
