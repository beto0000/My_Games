using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour, IEntity
{

    Animator anm;
    [SerializeField] public float health;
    public bool isDead;
    public float coincount;
    Button rightAttack, leftAttack,pauseButton;






    void Update()
    {
        if (!isDead)
            Attack();


    }



    void Start()
    {
        anm = GetComponent<Animator>();
        isDead = false;
        rightAttack=GameObject.Find("RightButton").GetComponent<Button>();
        leftAttack=GameObject.Find("LeftButton").GetComponent<Button>();
        

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyAttack") && !isDead)
        {
            TakeHit();
        }

    }


    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

            transform.localScale = new Vector3(1, 1, 1);
            anm.SetTrigger("attack");

        }
        if (Input.GetKeyDown(KeyCode.A))
        {

            transform.localScale = new Vector3(-1, 1, 1);
            anm.SetTrigger("attack");
        }


        rightAttack.onClick.AddListener(() => {
            transform.localScale = new Vector3(1, 1, 1);
            anm.SetTrigger("attack");
        });

        leftAttack.onClick.AddListener(() => {
            transform.localScale = new Vector3(-1, 1, 1);
            anm.SetTrigger("attack");
        });
    }

    public void TakeHit()
    {
        health -= 5;
        anm.SetTrigger("takehit");
        if (health <= 0)
        {
            isDead = true;
            anm.SetTrigger("death");
            GameManager.Instance.UIManager.YouDied();
        }
    }





}
