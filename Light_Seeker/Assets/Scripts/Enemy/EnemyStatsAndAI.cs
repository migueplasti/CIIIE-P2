using System.Collections;
using UnityEngine;

public class EnemyStatsAndAI : MonoBehaviour
{   

    private AudioSource audioSource;
    public AudioClip [] sounds;
    public float curHp;
    public float maxHp;

    public bool isDead;

    public bool inCombat;
    public float wanderTime;

    public GameObject target;

    public int attackRange;
    public int visionRange;

    public int AttackDamageMin;
    public int AttackDamageMax;

    public float AttackCooldownTimeMain;
    public float AttackCooldownTime;

    public float visualMemory;
    public float visualMemoryMain;

    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;
    public Effect effect;


    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();  
        audioSource = GetComponent<AudioSource>();
        effect = GetComponent<Effect>();
        curHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead){
            if (target == null){
                SearchForTargets();

                if (wanderTime > 0){
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isAttacking", false);     
                    FaceDirection(transform.forward);
                    agent.Move(transform.forward * Time.deltaTime * 3);
                    wanderTime -= Time.deltaTime;
                } else {
                    wanderTime = Random.Range (5.0f, 15.0f);
                    Wander();
                }
            } else {

                FollowTarget();

                if (visualMemory < 0 ){
                    target = null;
                } 
                visualMemory -= Time.deltaTime;
            }

        }

        if (curHp <= 0 && !isDead){
            isDead = true;
            curHp = 0;
            Death();
        }
        
    }

    void SearchForTargets(){
        Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(center, visionRange);
        int i = 0;

        while (i < hitColliders.Length) {
            if (hitColliders[i].transform.tag == "Player"){
                target = hitColliders[i].transform.gameObject;
                visualMemory = visualMemoryMain;
            }
            i++;
        }
    }

    void FollowTarget () {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        FaceTarget();

        float distance = Vector3.Distance(target.transform.position, this.transform.position);

        if (distance > attackRange){
            animator.SetBool("isWalking", true);
            animator.SetBool("isAttacking", false);
            agent.SetDestination(target.transform.position);
            agent.isStopped = false;
        } else {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);
            agent.isStopped = true;
            
            if (AttackCooldownTime > 0){
                AttackCooldownTime -= Time.deltaTime;

            } else {
                AttackCooldownTime = AttackCooldownTimeMain;
                AttackTarget();
            }
        }
    }

    void Wander() {
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
        Vector3 randomPosition = RandomNavSphere(transform.position, 30, UnityEngine.AI.NavMesh.AllAreas);

        FacePosition(randomPosition);
        agent.SetDestination(randomPosition);
    }

    void AttackTarget(){
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
        Debug.DrawRay(transform.position, transform.forward * (attackRange + 1), Color.white, 10);
        if (Physics.BoxCast(transform.position, transform.localScale, transform.forward, transform.rotation, attackRange, 8)) {
            print("Daño");
            target.GetComponent<Player>().TakeDamage(Random.Range(AttackDamageMin, AttackDamageMax));

            if (effect != null) {
                effect.apply(target);
            }
        }
    }

    public void RecieveDamage (float dmg){
        AudioClip hitSound = sounds[1];
        curHp -= dmg;
        audioSource.clip = hitSound;
        audioSource.Play();
        print("damage done = " + dmg);
        print("enemy hp = " + curHp);
    }

    void Death(){
        AudioClip deathSound = sounds[0];
        AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
        Destroy(this.gameObject);
    }

    void FaceTarget(){
        Vector3 direction = (target.transform.position - transform.position).normalized;
        FaceDirection(direction);
    }

    void FacePosition(Vector3 position){
        Vector3 direction = (position - transform.position).normalized;
        FaceDirection(direction);
    }

    void FaceDirection(Vector3 direction){
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        UnityEngine.AI.NavMeshHit navHit;
 
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}
