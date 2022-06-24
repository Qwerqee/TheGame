﻿using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    public GameObject pooledBullet;
    private bool notEnoughtBulletsInPool = true;
    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
            for (int i = 0; i < bullets.Count; i++)
                if (!bullets[i].activeInHierarchy) 
                    return bullets[i];

        if(notEnoughtBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }

        return null;
    }
}
