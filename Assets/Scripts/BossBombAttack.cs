using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombAttack : MonoBehaviour
{
    public GameObject explosionParticle;

    // private AudioSource bombAudio;//여기서 안할거면 의미 없는 코드;

    //public AudioClip bombExplosion;//폭탄 터질 때 소리

    // Start is called before the first frame update
    void Start()
    {
        //bombAudio = GetComponent<AudioSource>();//여기서 안할거면 의미 없는 코드;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Water" || collision.gameObject.tag == "Player")
        {
            //bombAudio.PlayOneShot(bombExplosion, 1.0f);//폭탄 터질 때 소리 함수 호출
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);

        }
    }
}
