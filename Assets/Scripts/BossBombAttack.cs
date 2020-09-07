using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombAttack : MonoBehaviour
{
    public GameObject explosionParticle;

    private AudioSource bombAudio;

    public AudioClip bombExplosion;

    // Start is called before the first frame update
    void Start()
    {
        bombAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Player")
        {
            bombAudio.PlayOneShot(bombExplosion, 1.0f);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);

        }
    }
}
