using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float damage = 10f;
    public void DestroyOnHit()
    {
        Destroy(gameObject);
    }
    public float Damage()
    {
        return damage;
    }
}
