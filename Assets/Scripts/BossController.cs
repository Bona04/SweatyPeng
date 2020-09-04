using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //Animator anime;
    public float cooltime;
    private float curtime;
    public GameObject BossNormalAttack;
    public Transform BossAttackPos;

    public GameObject BombAttack;
    public GameObject BombAim;

    private float randomXvalueCopy;

    private AudioSource bossAudio;

    public AudioClip aiming;
    public AudioClip bombFalling;
    public AudioClip basicShot;

    void Start()
    {
        //anime = GetComponent<Animator>();
        bossAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //기본공격
            {
                //anime.SetTrigger("NormalAttack");
                bossAudio.PlayOneShot(basicShot, 0.3f);
                Instantiate(BossNormalAttack, BossAttackPos.position, transform.rotation);
                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W))
        {
            float randomXvalue = Random.Range(100, 114);
            randomXvalueCopy = randomXvalue;

            StartCoroutine("BombAttackMethod");
        }
    }
    IEnumerator BombAttackMethod()
    {
        InvokeBombAim();
        yield return new WaitForSeconds(2);
        InvokeBomb();
    }
    void InvokeBombAim ()
    {
        bossAudio.PlayOneShot(aiming, 1.0f);
        Instantiate(BombAim, new Vector3(randomXvalueCopy, -2.2f, 0.0f), BombAim.transform.rotation);
    }
    void InvokeBomb ()
    {
        bossAudio.PlayOneShot(bombFalling, 1.0f);
        Instantiate(BombAttack, new Vector3(randomXvalueCopy, 4.0f, 0.0f), BombAttack.transform.rotation);
    }
}
