using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour {
    public GameObject cannon1, cannon2, cannon3;
    float timer1 = 1f;
    GameObject[] otherShips = new GameObject[3];
    public GameObject cannonBall;
    // Use this for initialization
    void Start () {
        GameObject[] ships = GameObject.FindGameObjectsWithTag("Ship");
        int count = 0;
        for(int i =0; i < 4; i++)
        {
            if (!ships[i].Equals(gameObject))
            {
                otherShips[count] = ships[i];
                count++;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer1 -= Time.deltaTime;
        if(timer1 <= 0)
        {

            fire(cannon1);
            //fire(cannon2);
            //fire(cannon3);
            timer1 = 1f;
        }




    }

    public void fire(GameObject cannon)
    {
        float[] distances = new float[3];
        distances[0] = Vector3.Distance(otherShips[0].transform.position, transform.position);
        distances[1] = Vector3.Distance(otherShips[1].transform.position, transform.position);
        distances[2] = Vector3.Distance(otherShips[2].transform.position, transform.position);
        int closest =0 ;
        float minDistance = distances[0];
        for(int i =1; i < 3; i++)
        {
            if(minDistance > distances[i])
            {
                closest = i;
                minDistance = distances[i];
            }
        }
        GameObject cannonShot = Instantiate(cannonBall, cannon.transform.position, Quaternion.identity);
        Vector3 direction = (otherShips[closest].transform.position - transform.position);
        Vector3 aim = new Vector3(direction.x, direction.y * 10, direction.z);
        cannonShot.GetComponent<Rigidbody>().AddForce( aim * 100);
        cannonShot.GetComponent<CannonBallScript>().setOwner(gameObject);
    }


}
