using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class weapons : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bullet;
    public GameObject akFlash;
    public GameObject p90Flash;
    public GameObject coltFlash;
    public GameObject shotgunFlash;
    public GameObject flashlightLight;
    private Light2D light;
    private AudioSource bang;
    public int flashBrightness;
    private int timer;
    private int fireTimer;
    public string currentWeapon;
    private Vector3 akPoint = new Vector3(1.655f, 0.055f, -28.40779f);
    private Vector3 p90Point = new Vector3(1.3897f, 0.07f, -28.40779f);
    private Vector3 coltPoint = new Vector3(1.382f, 0.138f, -28.40779f);
    private Vector3 shotgunPoint = new Vector3(2.124f, 0.136f, 0f);
    public Player player;
    private Store store;
    private bool mainWeapon;
    public int akTimer = 36;
    public int p90Timer = 18;
    public int coltTimer = 6;
    public int shotgunTimer = 120;

    private bool m_FacingRight = true;

    private void Start()
    {
        light = akFlash.GetComponent<Light2D>();
        bang = akFlash.GetComponentInChildren<AudioSource>();
        store = GameObject.Find("Store").GetComponent<Store>();
    }

    // Update is called once per frame
    void Update()
    {
        bool hasGun = false;
        bool automatic = false;

        if (currentWeapon == "ak47")
        {
            light = akFlash.GetComponent<Light2D>();
            bang = akFlash.GetComponentInChildren<AudioSource>();
            hasGun = true;
            automatic = true;
            firePoint.localPosition = akPoint;
            fireTimer = akTimer;
            flashBrightness = 7;
            mainWeapon = true;
            player.damage = player.akDamage;
        }
        else if (currentWeapon == "p90")
        {
            light = p90Flash.GetComponent<Light2D>();
            bang = p90Flash.GetComponentInChildren<AudioSource>();
            hasGun = true;
            automatic = true;
            firePoint.localPosition = p90Point;
            fireTimer = p90Timer;
            flashBrightness = 7;
            mainWeapon = true;
            player.damage = player.p90Damage;
        }
        else if (currentWeapon == "colt")
        {
            light = coltFlash.GetComponent<Light2D>();
            bang = coltFlash.GetComponentInChildren<AudioSource>();
            hasGun = true;
            automatic = false;
            firePoint.localPosition = coltPoint;
            fireTimer = coltTimer;
            flashBrightness = 7;
            mainWeapon = false;
            player.damage = player.coltDamage;
        }
        else if (currentWeapon == "flashlight")
        {
            light = flashlightLight.GetComponent<Light2D>();
            hasGun = false;
            timer = 0;
            fireTimer = 0;
            flashBrightness = 7;
            mainWeapon = false;
        }
        else if (currentWeapon == "shotgun")
        {
            light = shotgunFlash.GetComponent<Light2D>();
            bang = shotgunFlash.GetComponentInChildren<AudioSource>();
            hasGun = true;
            automatic = false;
            firePoint.localPosition = shotgunPoint;
            fireTimer = shotgunTimer;
            flashBrightness = 7;
            mainWeapon = true;
            player.damage = player.shotgunDamage;
        }

        if (!store.InStore)
        {
            if (mainWeapon && player.MainAmmo > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) && hasGun && timer == 0)
                {
                    timer = fireTimer;
                    light.intensity = flashBrightness;
                    Shoots();

                    if (currentWeapon == "shotgun" && player.MainAmmo > 4)
                    {
                        player.MainAmmo -= 5;
                    }else {
                        player.MainAmmo--;
                    }

                    
                }
                else if (Input.GetKey(KeyCode.Space) && hasGun && automatic && timer == 0)
                {
                    timer = fireTimer;
                    light.intensity = flashBrightness;
                    Shoots();
                    player.MainAmmo--;
                }
                else if (timer == (fireTimer - 6) && timer != 0)
                {
                    timer--;
                    light.intensity = 0;
                }
                else if (timer > 0)
                {
                    timer--;
                }
                else
                {
                    light.intensity = 0;
                }
            }
            else if (!mainWeapon && currentWeapon != "flashlight" && player.SideAmmo > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) && hasGun && timer == 0)
                {
                    timer = fireTimer;
                    light.intensity = flashBrightness;
                    Shoots();
                    player.SideAmmo--;
                }
                else if (Input.GetKey(KeyCode.Space) && hasGun && automatic && timer == 0)
                {
                    timer = fireTimer;
                    light.intensity = flashBrightness;
                    Shoots();
                    player.SideAmmo--;
                }
                else if (timer == (fireTimer - 6) && timer != 0)
                {
                    timer--;
                    light.intensity = 0;
                }
                else if (timer > 0)
                {
                    timer--;
                }
                else
                {
                    light.intensity = 0;
                }
            }
            else
            {
                if (currentWeapon == "flashlight" && Input.GetKey(KeyCode.Space))
                {
                    light.intensity = flashBrightness;
                }
                else
                {
                    light.intensity = 0;
                }
            }
        }
    }

    void Shoots()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        bang.Play();
    }
    void OnCollisionEnter(Collision Other)
    {
        Destroy(bullet);
    }




}


