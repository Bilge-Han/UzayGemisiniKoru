using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 4f;
    public float healthEnemy = 100f;
    public float saniyeBasinaMermiAtma = 0.6f;
    public int scorePoint = 200;
    private ScoreManager scoreManager;
    public AudioClip AtesSesi;
    public AudioClip OlumSesi;
    public Slider slider;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletManager hitBullet = collision.gameObject.GetComponent<BulletManager>();
        if (hitBullet)
        {
            hitBullet.DestroyOnHit();
            healthEnemy -= hitBullet.Damage();
            slider.value = healthEnemy;
            if (healthEnemy<=0)
            {
                Destroy(gameObject);
                scoreManager.ScorePlus(scorePoint);
                AudioSource.PlayClipAtPoint(OlumSesi, transform.position);
            }
        }
    }
    private void Start()
    {
        scoreManager =  GameObject.Find("Score").GetComponent<ScoreManager>();
        slider.maxValue = healthEnemy;
        slider.value = healthEnemy;
    }
    private void Update()
    {
        float atmaOlasiligi = Time.deltaTime * saniyeBasinaMermiAtma;
        if (Random.value<atmaOlasiligi)
        {
            ShootBullet();
        }
    }
    void ShootBullet()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1f, 0);
        GameObject enemyBullet = Instantiate(bullet, startPosition, Quaternion.identity) as GameObject;
        enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
        AudioSource.PlayClipAtPoint(AtesSesi, transform.position);
    }
}
