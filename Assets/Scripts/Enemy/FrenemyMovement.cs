using UnityEngine;
using System.Collections;

public class FrenemyMovement : MonoBehaviour
{ 
  
    public Vector3 Target;
    Transform player;
    GameObject followingEnemy;
   
    PlayerHealth playerHealth;
    EnemyHealth myHealth;
    UnityEngine.AI.NavMeshAgent nav;



    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        myHealth = gameObject.GetComponent<EnemyHealth>();
        nav = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        followingEnemy = gameObject.GetComponent<FrenemyAttack>().followingEnemy;


        if (myHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            if (followingEnemy != null)
            {   
                if (followingEnemy.activeSelf)
                {
                    nav.SetDestination(followingEnemy.transform.position);
                }
                else
                {
                    changeTarget();
                }
                
            }
            else
            {
                changeTarget();
            }
        }

    }

    

 
    void changeTarget()
    {
        float oldX = gameObject.transform.position.x;
        float oldZ = gameObject.transform.position.z;
        float oldY = gameObject.transform.position.y;

        float xPos = oldX + Random.Range(-100,100);
        float zPos = oldZ + Random.Range(-100,100);

        Target = new Vector3(xPos,oldY,zPos);
        nav.SetDestination(Target);


    }

}   

