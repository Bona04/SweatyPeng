using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombAttack : MonoBehaviour
{
    public GameObject explosionParticle;

<<<<<<< HEAD

   //private AudioSource bombAudio;//여기서 안할거면 의미 없는 코드;


//    public AudioClip bombExplosion;
=======
    private AudioSource bombAudio;

    public AudioClip bombExplosion;
>>>>>>> parent of 4cab7c7... 뭐 이것저것..

    void Start()
<<<<<<< HEAD
    { 
        //bombAudio = GetComponent<AudioSource>();
=======
    {
        bombAudio = GetComponent<AudioSource>();
>>>>>>> parent of 4cab7c7... 뭐 이것저것..
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Player")
<<<<<<< HEAD
        { 
            //bombAudio.PlayOneShot(bombExplosion, 1.0f);
=======
        {
            bombAudio.PlayOneShot(bombExplosion, 1.0f);
>>>>>>> parent of 4cab7c7... 뭐 이것저것..
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);

        }
    }
}
