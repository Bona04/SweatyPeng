using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuriAttack : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Invoke("DestroyBullet", 1);
    }


    void Update()
    {
        if (transform.rotation.y == 0)
            transform.Translate(transform.right * speed * Time.deltaTime);

        else
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
    }

    void DestroyBullet() // 소멸
    {
        Destroy(gameObject);
    }
}