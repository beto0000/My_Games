using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IEntity
{

    Animator anm;
    [SerializeField] public float health;
    bool isDead, isAttack, isTakeHit;
    [SerializeField] public float attackrange = 2f, localscale;
    float attackcooltimer = 0f;
    [SerializeField] public float attacktimer = 5f;
    Transform player;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float destroytime;



    private void Start()
    {
        anm = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        isDead = false;
    }

    public virtual void Update()
    {
        if (!isDead)
        {
            Move();
            Attack();
        }
        StartCoroutine(Destroy(destroytime));

    }

    public IEnumerator Destroy(float deathtimer)
    {
        if (isDead)
        {
            yield return new WaitForSeconds(deathtimer);
            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerSword") && !isDead)
        {
            TakeHit();
            isTakeHit = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerSword") && !isDead)
        {
            isTakeHit = false;
        }
    }

    public void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackrange)
        {
            isAttack = true;
            anm.SetBool("move", false);
            if (Time.time - attackcooltimer > attacktimer)
            {
                anm.SetTrigger("attack");
                attackcooltimer = Time.time;
            }
        }
        else isAttack = false;
    }





    public void Move()
    {
        localscale = transform.position.x - player.position.x;
        if (localscale > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (localscale < 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (!isAttack && !isTakeHit)
        {
            anm.SetBool("move", true);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

    }

    public void TakeHit()
    {
        health -= 5;
        if (!isDead)
            anm.SetTrigger("takehit");
        if (health <= 0)
        {
            isDead = true;
            anm.SetTrigger("death");
            GameManager.Instance.highscore++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackrange);
    }
}
