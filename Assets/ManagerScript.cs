using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour {

    public GameObject cubePrefab;
    public GameObject spherePrefab, shipPrefab;
    public Material[] materials = new Material[4];
    float offSet =1;
    public GameObject text;
    string[] texts = new string[4];
    int count = 0;
    // Use this for initialization
    void Start () {
        texts[0] = "Calm Seas";
        texts[1] = "Slight Weather";
        texts[2] = "Moderate Weather";
        texts[3] = "Storm";
        text.GetComponent<TextMesh>().text = texts[count];
        for (int i = 0; i < 20; i++)
        {
            for(int j = 0; j < 20; j++)
            {
               Instantiate(cubePrefab, new Vector3(i*offSet, 0, j*offSet), Quaternion.identity);
            }
        }

        for(int i = 0; i < 4; i++)
        {
            float x = Random.Range(0, 16);
            float z = Random.Range(0, 16);
            GameObject sphere = Instantiate(spherePrefab, new Vector3(x, 1.444f, z), Quaternion.identity);
            GameObject ship = Instantiate(shipPrefab, new Vector3(x, 1.444f, z), Quaternion.identity);
            ship.GetComponent<FollowSphere>().setSphere(sphere);
            ship.GetComponent<FollowSphere>().setFlagColor(materials[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            count--;
            text.GetComponent<TextMesh>().text = texts[count];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            count++;
            text.GetComponent<TextMesh>().text = texts[count];
        }
    }
}
