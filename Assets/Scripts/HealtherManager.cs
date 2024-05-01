using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtherManager : MonoBehaviour
{
    public void DestroyOnHit()
    {
        Destroy(gameObject);
    }
}
