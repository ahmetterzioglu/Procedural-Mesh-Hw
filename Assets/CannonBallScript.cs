using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour {
    GameObject owner;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setOwner(GameObject owner)
    {
        this.owner = owner;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Sea"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.Equals(owner))
        {

        }else
        {

        Destroy(gameObject);
        }
    }
}
