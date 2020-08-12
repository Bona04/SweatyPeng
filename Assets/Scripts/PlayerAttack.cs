using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject rightAttack;
    public GameObject leftAttack;
    public SpriteRenderer spriteRenderer;
    public Transform rightPos;
    public Transform leftPos;
    public float cooltime;
    private float curtime;
    Animator anime;


    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z)) //기본공격
            {
                anime.SetTrigger("Attack");
                if (!spriteRenderer.flipX)
                    Instantiate(rightAttack, rightPos.position, transform.rotation);
                else
                    Instantiate(leftAttack, leftPos.position, transform.rotation);

                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;

    }
}
