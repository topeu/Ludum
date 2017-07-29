using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AIGO : MonoBehaviour {
    public GameObject Emery;
    private Transform gm1;
    public float timer;
    public bool yes;
    public float newtimer;
	// Use this for initialization
	void Start () {
        gm1 = GetComponent<AICharacterControl>().target;
        newtimer = timer;
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gm1 = other.gameObject.transform;
            this.GetComponent<AICharacterControl>().target = gm1;
            Emery.GetComponent<NavMeshAgent>().enabled = true;
           // Emery.GetComponent<Animator>().SetTrigger ("")
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            yes = true;
        }
    }
    void Update()
    {
        if (yes = true)
        {
            timer -= Time.deltaTime;
        }
        if(timer < 0)
        {
            Emery.GetComponent<NavMeshAgent>().enabled = false;
            yes = false;
            timer = newtimer;
            //Emery.GetComponent<Animator>().SetTrigger("Idle");
        }
    }
}
