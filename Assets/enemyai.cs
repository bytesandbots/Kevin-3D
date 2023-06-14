using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyai : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public Animator animate;
    public GameObject player;
    public float cooldown = 2f;
    private float cdtime = 0;
    public bool CD;
    private bool alrplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animate.SetFloat("speed", agent.velocity.magnitude);
        if (player.GetComponent<Health>().currenthealth <= 0)
        {
            agent.isStopped = true;
            return;
        }
        agent.SetDestination(target.position);
        if (Vector3.Distance(player.transform.position, transform.position) < 16f)
        {
            if (!alrplay)
            {
                Camera.main.GetComponent<AudioSource>().Play();
                alrplay = true;
            }
           
        }
        else
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            alrplay = false;
        }
        if (Vector3.Distance(player.transform.position, transform.position) < 10f && CD == false) 
        {
            transform.LookAt(player.transform);
            animate.SetTrigger("Attack");
            CD = true;
        }
        if(CD == true)
        {
            if(cdtime >= cooldown)
            {
                CD = false;
                cdtime = 0;
            }
            else
            {
                cdtime += Time.deltaTime;
            }
        }
    }
}
