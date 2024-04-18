using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    // Start is called before the first frame update
    public float offset;

    private GameObject player;
    private SpriteRenderer spriteren;
    public GameObject Bullet;
    public Transform ShootPoint;
    // public Animator anim; 



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

        
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        

        if(rotZ < 89 && rotZ > -89)
        {
            player.transform.localScale = new Vector2(1,1);
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
        else
        {
            player.transform.localScale = new Vector2(-1,1);
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ-180);
        }

        /*if(difference.x<transform.position.x)
        { 
            transform.eulerAngles = new Vector3(transform.rotation.x,180f,transform.rotation.z);
        } 
        else
        { 
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        */
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > readyForNextShoot)
            {
                readyForNextShoot = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {

        /*GameObject BulletIns = Instantiate(Bullet, ShootPoint.transform.position, ShootPoint.transform.rotation);*/
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, transform.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
        // anim.SetTrigger("Shoot");

    }



}
