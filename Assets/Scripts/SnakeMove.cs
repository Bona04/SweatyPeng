﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;

    public int nextMove;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        Invoke("Think", 5); //5초 뒤에 호출
    }

    void Update()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);   //기본 움직임

        //지형 체크
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.3f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            //Debug.Log("경고! 이 앞 낭떠러지.");
            Turn();
        }
    }
    void Think() //재귀함수
    {
        //Set Next Active
        nextMove = Random.Range(-1, 2); //최소값, 최대값-1


        //Flip Sprite
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        //Recursive
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
    void Turn()
    {
        nextMove = nextMove * -1; //방향 정반대로 바꿔줌.
        spriteRenderer.flipX = nextMove == 1;
        CancelInvoke();
        Invoke("Think", 2);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //기본공격과 충돌
        if (collision.gameObject.tag == "normalAttack")
        {
            //Damaged 
            OnDamaged(collision.transform.position);
        }
    }
    private void OnDamaged(Vector2 targetPos)
    {
        //health down

        //레이어 변경
        gameObject.layer = 12;

        spriteRenderer.color = new Color(1, 1, 1, 0.4f); //마지막이 투명도

        //튕겨 나감
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 2, ForceMode2D.Impulse);

        //Invoke("OffDamagedEnemy", 3); //무적시간
        StartCoroutine("DamagedDelay");
    }
    IEnumerator DamagedDelay()
    {
        yield return new WaitForSeconds(2f);

        gameObject.layer = 11; //레이어 다시 돌려놓음
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
