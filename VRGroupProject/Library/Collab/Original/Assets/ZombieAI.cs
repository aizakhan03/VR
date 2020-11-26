using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    
    NavMeshAgent nm;
    private Transform target;
    public enum AIState { chasing, hit, dead};

    public AIState aiState = AIState.chasing;
    public Animator animator;
    public float distanceThreshold = 5f;

    public int health;

    
    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        nm = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        target = GameObject.FindGameObjectWithTag("Player").transform; // for some reason doesnt work
        //I think its because start() happens at the very beginning of the game? at not when created?  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Think()
    {
        bool only_once = true;
        if(only_once)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform; //moved to here
            only_once = false;
        }
        while(true)
        {
            float dist;
            switch(aiState)
            {
                case AIState.chasing:

                    dist = Vector3.Distance(target.position, transform.position);
                    if(dist < distanceThreshold)
                    {
                        aiState = AIState.hit;
                    }
                    nm.SetDestination(target.position);
                    animator.SetBool("Chasing", true);
                    break;

                case AIState.hit:
                    dist = Vector3.Distance(target.position, transform.position);
                    if(dist > distanceThreshold)
                    {
                        aiState = AIState.chasing;
                    }
                    nm.SetDestination(target.position);
                    GameObject player = GameObject.Find("Player");
                    player.GetComponent<PlayerStuff>().currentHealth -= 1;
                    player.GetComponent<PlayerStuff>().healthBar.setHealth(player.GetComponent<PlayerStuff>().currentHealth);
                    break;

                case AIState.dead:
                    break;

                default:
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    


}
