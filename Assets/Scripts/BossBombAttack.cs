using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombAttack : MonoBehaviour
{
    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * 2);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water")
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);

        }
    }
}
