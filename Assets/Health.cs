using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxhealth = 100;
    public float currenthealth;
    public Image healthbar;
    private bool cooldown;
    public float cooldowntime = 0.5f;
    private float timecd = 0;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = false;
        currenthealth = maxhealth;
        healthbar.fillAmount = currenthealth / maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown)
        {
            if (timecd <= cooldowntime)
            {
                timecd += Time.deltaTime;
            }
            else
            {
                cooldown = false;
                timecd = 0;
            }
            
        }
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (cooldown == false)
            {
                currenthealth = currenthealth - 25;
                healthbar.fillAmount = currenthealth / maxhealth;
                cooldown = true;
                if (currenthealth == 0)
                {
                    GetComponent<playerMovement>().enabled = false;
                    anim.SetTrigger("death");
                    GetComponent<Rigidbody>().isKinematic = true;
                    GetComponentInChildren<faceMovingDirection>().enabled = false;
                }
            }
        }
    }
}
