using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //Animator anime;
    //public float cooltime;
    //private float curtime;
    public GameObject BossNormalBullet;
    public Transform BossAttackPos;
    public GameObject missileAim;
    public GameObject BossMissileBullet;

    public GameObject BombAttack;
    public GameObject BombAim;

    private float randomXvalueCopy;

    private AudioSource bossAudio;

    public AudioClip aiming;
    public AudioClip bombFalling;
    public AudioClip basicShot;

    public GameManager gameManager;

    void Start()
    {
        //anime = GetComponent<Animator>();
        bossAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            NormalAttack();
        }
        if (Input.GetKeyDown(KeyCode.W)) //폭탄 공격
        {
            float randomXvalue = Random.Range(100, 114);
            randomXvalueCopy = randomXvalue;

            StartCoroutine("BombAttackMethod");
        }

        if (Input.GetKeyDown(KeyCode.E)) //미사일 공격
        {
            MissileAttack();
        }
    }
    void NormalAttack()
    {
        Instantiate(BossNormalBullet, BossAttackPos.position, transform.rotation);
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

    void MissileAttack()
    {
        StartCoroutine("MissileAimActive");
    }
    IEnumerator MissileAimActive()
    {
        missileAim.SetActive(true);
        yield return new WaitForSeconds(2);
        missileAim.SetActive(false);
        Instantiate(BossMissileBullet, BossAttackPos.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(BossMissileBullet, BossAttackPos.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(BossMissileBullet, BossAttackPos.position, transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //기본공격과 충돌
        if (collision.gameObject.tag == "normalAttack" && gameManager.BossHpBar.value > 0)
        {
            //Damaged 
            gameManager.BossHealthDown();
            gameManager.FilledIce();  //얼음 차기
        }
        //얼음공격과 충돌하면
        if (collision.gameObject.tag == "IceAttack"  && gameManager.BossHpBar.value > 0)
        {
            //피해입기
            gameManager.BossHealthDownIce();
        }
    }
}
