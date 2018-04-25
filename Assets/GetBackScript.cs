using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBackScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+0.3f, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        }

        if (transform.position.y < -1)
        {
            float x = Random.Range(4, 12);
            float z = Random.Range(4, 12);
            transform.position = new Vector3(x, 1.4f, z);
        }
	}
}
