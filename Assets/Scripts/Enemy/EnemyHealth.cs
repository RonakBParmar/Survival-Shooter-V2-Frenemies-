using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    private GameObject alterEgo;
    public GameObject alterEgoPrefab;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();


    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        ScoreManager.score += scoreValue;
        Debug.Log("Death to " + gameObject.name);
        if (alterEgo) Destroy(alterEgo);
        Destroy (gameObject, 2f);
    }

    public void Convert () // convert to alter Ego
    {
        if (alterEgo == null)
        {
            if (alterEgoPrefab == null) return; // I cannot be converted
            alterEgo = Instantiate(alterEgoPrefab, transform.position, transform.rotation);
            alterEgo.GetComponent<EnemyHealth>().alterEgo = gameObject;
            // Debug.Log("Created alter Ego for " + gameObject.name);
        }
        alterEgo.transform.SetPositionAndRotation(transform.position, transform.rotation);
        gameObject.SetActive(false);
        alterEgo.SetActive(true);
    }

}
