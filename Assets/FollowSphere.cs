using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSphere : MonoBehaviour {
    GameObject sphere;
    Vector3 lastRotation = new Vector3(1,0,0);
    public GameObject flag, sail1, sail2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 oldPosition = transform.position;
        Vector3 newPosition = sphere.transform.position;
        transform.position = newPosition;
        Vector3 direction = (newPosition - oldPosition).normalized;
        direction = new Vector3(direction.x, (direction.y + lastRotation.y) /12,direction.z);
        //direction = new Vector3(direction.x, direction.y*20, direction.z);
        lastRotation = direction ;
        transform.rotation = Quaternion.LookRotation(direction);

        //transform.rotation = Quaternion.Euler(0, 0, transform.rotation.z);
        //transform.rotation = Quaternion.Euler(0, sphere.transform.rotation.y, 0);
	}

    public void setSphere(GameObject sphere)
    {
        this.sphere = sphere;
    }

    public void setFlagColor(Material color)
    {
        flag.GetComponent<MeshRenderer>().material = color;
        sail1.GetComponent<MeshRenderer>().material = color;
        sail2.GetComponent<MeshRenderer>().material = color;
    }
}
