using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float speedEnemy = 2f;
    public float genislik;
    public float yukseklik;
    public bool rightMove = true;
    float xmin, xmax;
    public float createDelay = 1f;
    void Start()
    {
        positionSet();
        EnemyCreate();
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(genislik, yukseklik));
    }
    void Update()
    {
        enemyHorizontalMove();
        if (AllEnemyDead())
        {
            EnemySoloCreate();
        }
    }
    void positionSet()
    {
        float objeIleKameraninuzaklik = transform.position.z - Camera.main.transform.position.z;
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, objeIleKameraninuzaklik));
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, objeIleKameraninuzaklik));
        xmax = sagUc.x;
        xmin = solUc.x;
    }
    bool AllEnemyDead()
    {
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }
    void enemyHorizontalMove()
    {
        if (rightMove == true)
        {
            //transform.position += new Vector3(speedEnemy * Time.deltaTime, 0, 0);
            transform.position += speedEnemy * Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += speedEnemy * Vector3.left * Time.deltaTime;
        }
        float sagSinir = transform.position.x + genislik / 2;
        float solSinir = transform.position.x - genislik / 2;
        if (sagSinir > xmax)
        {
            rightMove = false;
        }
        else if (solSinir < xmin)
        {
            rightMove = true;
        }
    }
    void EnemyCreate()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }
    Transform SonrakiUygunPozisyon()
    {
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount == 0)
            {
                return childPosition;
            }
        }
        return null;
    }
    void EnemySoloCreate()
    {
        Transform uygunPosition = SonrakiUygunPozisyon();
        if (uygunPosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, uygunPosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = uygunPosition;
        }
        if (SonrakiUygunPozisyon())
        {
            Invoke("EnemySoloCreate", createDelay);
        }
    }
   
}
