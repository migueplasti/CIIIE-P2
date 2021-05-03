using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public string enemyName;
    public float curHp;
    public float maxHp;

    public GameObject TextName;
    public bool isSelected;

    public float corpseTimer;

    public bool isDead;

    public bool inCombat;
    public float wanderTime;
    public float movementSpeed;

    public GameObject target;

    public int attackRange;
    public int visionRange;

    public int AttackDamageMin;
    public int AttackDamageMax;

    public float AttackCooldownTimeMain;
    public float AttackCooldownTime;

    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead){
            if (target == null){
                SearchForTargets();

                if (wanderTime > 0){
                    agent.Move(Vector3.forward * Time.deltaTime);
                    wanderTime -= Time.deltaTime;
                } else {
                    wanderTime = Random.Range (5.0f, 15.0f);
                    Wander();
                }
            } else {
                FollowTarget();
            }

        }

        if (curHp <= 0 && !isDead){
            isDead = true;
            curHp = 0;
            Destroy(this.gameObject);
        }
        
    }

    void SearchForTargets(){
        Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Collider[] hitColliders = Physics.OverlapSphere(center, visionRange);
        int i = 0;

        while (i < hitColliders.Length) {
            if (hitColliders[i].transform.tag == "Player"){
                target = hitColliders[i].transform.gameObject;
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
        transform.eulerAngles = new Vector3 (0, Random.Range(0, 360), 0);
    }

    void AttackTarget(){
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
        
        // target.transform.GetComponent<UserStats> ()
        print("Daño");
    }

    public void RecieveDamage (float dmg){
        curHp -= dmg;

        print("damage done = " + dmg);
        print("enemy hp = " + curHp);
    }

    IEnumerator Death(){
        yield return new WaitForSeconds (corpseTimer);

        Destroy(this.gameObject);
    }

    void FaceTarget(){
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
