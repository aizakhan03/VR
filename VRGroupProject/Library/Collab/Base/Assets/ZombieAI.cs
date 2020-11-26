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
                    nm.SetDestination(target.position);
                    if(dist < distanceThreshold)
                    {
                        aiState = AIState.hit;
                        animator.SetBool("Chasing", false);
                        animator.SetBool("Hit", true);
                        
                    }
                    
                    
                    break;

                case AIState.hit:
                    dist = Vector3.Distance(target.position, transform.position);
                    nm.SetDestination(transform.position);
                    if(dist > distanceThreshold)
                    {
                        aiState = AIState.chasing;
                        animator.SetBool("Chasing", true);
                        animator.SetBool("Hit", false);
                    }

                    dist = Vector3.Distance(target.position, transform.position);
                    if(dist < distanceThreshold && animator.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack"))
                    {
                        GameObject player = GameObject.Find("Player");
                        player.GetComponent<PlayerStuff>().currentHealth -= 1;
                        player.GetComponent<PlayerStuff>().healthBar.setHealth(player.GetComponent<PlayerStuff>().currentHealth);

                        if(player.GetComponent<PlayerStuff>().currentHealth <= 0)
                        {

                            //Player display LOSE SCREEN
                            //GIVE PLAYER OPTION TO RESTART OR EXIT

                        }
                    }
                    break;

                case AIState.dead:
                    animator.SetBool("Chasing", false);
                    animator.SetBool("Hit", false);
                    animator.SetBool("Dead", true);
                    break;

                default:
                    break;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    


}
