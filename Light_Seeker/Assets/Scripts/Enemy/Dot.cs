using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour, Effect
{
    public int currentDots;

    public GameObject target;

    public int DotDamageMin;
    public int DotDamageMax;

    public float DotCooldownTimeMain;
    public float DotCooldownTime;
    public int dotsPerAttack;
    
// Start is called before the first frame update
    void Start()
    {
        currentDots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDots > 0){
            if (DotCooldownTime > 0){
                DotCooldownTime -= Time.deltaTime;
            } else {
                DotCooldownTime = DotCooldownTimeMain;
                target.GetComponent<Player>().TakePenDamage(Random.Range(DotDamageMin, DotDamageMax));
                currentDots--;
            }
        }
    }
    public void apply(GameObject target1){
        target = target1;
        currentDots += dotsPerAttack;
    }
}