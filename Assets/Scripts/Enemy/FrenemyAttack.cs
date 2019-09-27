using UnityEngine;
using System.Collections;

public class FrenemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    //Animator anim;
    GameObject player;
    GameObject zomBear;
    GameObject zomBunny;
    GameObject hellephant;
    public GameObject followingEnemy;
    PlayerHealth playerHealth;
    EnemyHealth myHealth;
    public bool enemyInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        myHealth = gameObject.GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == zomBear || other.gameObject == zomBunny || other.gameObject == hellephant)//locating the type
        {
            enemyInRange = true;
            followingEnemy = other.gameObject;

        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == zomBear || other.gameObject == zomBunny || other.gameObject == hellephant)
        {
            enemyInRange = false;
        }
    }


    void Update()
    {
        zomBear = GameObject.Find("ZomBear(Clone)");
        zomBunny = GameObject.Find("Zombunny(Clone)");
        hellephant = GameObject.Find("Hellephant(Clone)");
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && enemyInRange && myHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            //anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            if (myHealth.currentHealth > 0)
            {
                EnemyHealth followingEHealth = followingEnemy.GetComponent<EnemyHealth>();
                myHealth.TakeDamage(attackDamage,transform.position);
                followingEHealth.TakeDamage(attackDamage, followingEnemy.transform.position);
                
            }
        }


    }
}
