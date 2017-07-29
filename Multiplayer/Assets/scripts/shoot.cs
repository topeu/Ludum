using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class shoot : NetworkBehaviour {
    public GameObject bullet;
    private GameObject bulletreal;
    int i;
	// Use this for initialization
	void Start () {
        i = 0;
        /*if (isLocalPlayer)
        {
            GetComponent<FirstPersonController>().enabled = true;
            GetComponentInChildren<Camera>().enabled = true;
            GetComponent<CharacterController>().enabled = true;
        }*/
        bulletreal.AddComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        i++;
        /*if (isLocalPlayer)        
        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log(playerControllerId);
            bulletreal = Instantiate(bullet);
            bulletreal.transform.position = this.transform.position;
            bulletreal.GetComponent<Rigidbody>().AddForce(transform.right * 50);
        }*/
        if (i % 100 == 47){
            bulletreal = Instantiate(bullet);
            bulletreal.transform.position = this.transform.position;
            bulletreal.GetComponent<Rigidbody>().AddForce(transform.right * 50);
        }
		//GetMouseInputs();
	}

	// Detect Mouse Inputs
  /*  void GetMouseInputs()
    {
       
        if (!isLocalPlayer)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            bulletreal = Instantiate(bullet);
            bulletreal.transform.position = this.transform.position;
            bulletreal.GetComponent<Rigidbody>().AddForce(transform.right * 50);
        }
    }*/
}
