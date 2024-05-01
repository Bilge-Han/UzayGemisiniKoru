using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uzay_Gemisi_Kontrol : MonoBehaviour
{
    public float speedShip = 10f;
    public float inceAyar = 0.7f;
    float xmin, xmax;
    public GameObject bullet;
    public float bulletSpeed = 5f;
    public float atesEtmeAraligi = 1f;
    public float healthShip = 100f;
    public AudioClip AtesSesi;
    public AudioClip OlumSesi;
    public Slider slider;
    public MenuManagerInGameScreen MenuManagerInGameScreen;
    public GameObject healther;
    public Transform[] spawnPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Healther")
        {
            HealtherManager healtherManager = collision.gameObject.GetComponent<HealtherManager>();
            healtherManager.DestroyOnHit();
            healthShip = 100;
            slider.value = healthShip;
        }
        if (collision.tag=="BulletEnemy")
        {
            BulletManager hitBullet = collision.gameObject.GetComponent<BulletManager>();
            if (hitBullet)
            {
                hitBullet.DestroyOnHit();
                healthShip -= hitBullet.Damage();
                slider.value = healthShip;
                if (healthShip <= 0)
                {
                    Destroy(gameObject);
                    AudioSource.PlayClipAtPoint(OlumSesi, transform.position);
                    MenuManagerInGameScreen.GameOverManage();
                }
            }
        }
    }
    void Start()
    {
        positionSet();
        slider.maxValue = healthShip;
        slider.value = healthShip;
    }
    void Update()
    {
        HorizontalMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //shotBullet();
            InvokeRepeating("shootBullet", 0.001f,atesEtmeAraligi);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("shootBullet");
        }
    }
    void shootBullet()
    {
        GameObject shipBullet = Instantiate(bullet, transform.position + new Vector3(0,1f,0), Quaternion.identity) as GameObject;
        shipBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
        AudioSource.PlayClipAtPoint(AtesSesi,transform.position);
    }
    void positionSet()
    {
        float uzaklik = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, uzaklik));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklik));
        xmin = solUc.x + inceAyar;
        xmax = sagUc.x - inceAyar;

    }
    void HorizontalMove()
    {
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += new Vector3(-speedShip*Time.deltaTime,0,0);
            transform.position += Vector3.left * speedShip * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(speedShip*Time.deltaTime, 0, 0);
            transform.position += Vector3.right * speedShip * Time.deltaTime;
        }
    }
 
}
