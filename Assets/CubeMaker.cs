using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class CubeMaker : MonoBehaviour
{
    Vector3 size = Vector3.one;
    float timer = 0;
    MeshCreator mc;
    Mesh oldMesh;
    float scale = 16;
    // Update is called once per frame
    void Start()
    {
         mc = new MeshCreator();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            scale+=4;
            Debug.Log("Scale: " + scale);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            scale-=4;
            Debug.Log("Scale: " + scale);
        }
        mc.cleanUp();
        timer += Time.deltaTime/ 2;
        if (timer > 255)
        {
            timer = 0;
        }
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        MeshCollider meshCollider = this.GetComponent<MeshCollider>();
        // one submesh for each face        
        Vector3 cubeSize = size * 0.5f;
     
        // top of the cube        
        // t0 is top left point      
        float perlinX1 = (transform.position.x + cubeSize.x) / scale ;
        float perlinX2 = (transform.position.x - cubeSize.x) / scale;

        float perlinY1 = (transform.position.z - cubeSize.z) / scale;
        float perlinY2 = (transform.position.z + cubeSize.z) / scale;

        //Calculate each top vertex height individually
        float height1 = Perlin.Noise(perlinX1, perlinY1, timer) * 1.2f + 0.9f;
        float height2 = Perlin.Noise(perlinX2, perlinY1, timer) * 1.2f + 0.9f;
        float height3 = Perlin.Noise(perlinX2, perlinY2, timer) * 1.2f + 0.9f;
        float height4 = Perlin.Noise(perlinX1, perlinY2, timer) * 1.2f + 0.9f;

        Vector3 position = GetComponentInChildren<ParticleSystem>().GetComponentInParent<Transform>().position;
        GetComponentInChildren<ParticleSystem>().GetComponentInParent<Transform>().position =new Vector3(position.x, ((height1 + height2 + height3 + height4) / 4f), position.z);

        if ((((height1 + height2 + height3 + height4) / 4f) > 1.2f) && !GetComponentInChildren<ParticleSystem>().isPlaying)
        {
            GetComponentInChildren<ParticleSystem>().Play();
        }

        Vector3 t0 = new Vector3(cubeSize.x, height1, -cubeSize.z);
        Vector3 t1 = new Vector3(-cubeSize.x, height2, -cubeSize.z);
        Vector3 t2 = new Vector3(-cubeSize.x, height3, cubeSize.z);
        Vector3 t3 = new Vector3(cubeSize.x, height4, cubeSize.z);
        // bottom of the cube        
        Vector3 b0 = new Vector3(cubeSize.x, -cubeSize.y, -cubeSize.z);
        Vector3 b1 = new Vector3(-cubeSize.x, -cubeSize.y, -cubeSize.z);
        Vector3 b2 = new Vector3(-cubeSize.x, -cubeSize.y, cubeSize.z);
        Vector3 b3 = new Vector3(cubeSize.x, -cubeSize.y, cubeSize.z);
        // Top square        
        mc.BuildTriangle(t0, t1, t2);
        mc.BuildTriangle(t0, t2, t3);
        // Bottom square       
        mc.BuildTriangle(b2, b1, b0);
        mc.BuildTriangle(b3, b2, b0);
        // Back square   
        mc.BuildTriangle(b0, t1, t0);
        mc.BuildTriangle(b0, b1, t1);
        mc.BuildTriangle(b1, t2, t1);
        mc.BuildTriangle(b1, b2, t2);
        mc.BuildTriangle(b2, t3, t2);
        mc.BuildTriangle(b2, b3, t3);
        mc.BuildTriangle(b3, t0, t3);
        mc.BuildTriangle(b3, b0, t0);

        meshFilter.mesh.Clear();
        Destroy(oldMesh);
        oldMesh = mc.CreateMesh();
        meshCollider.sharedMesh = oldMesh;
        meshFilter.mesh = oldMesh;
       
    }

    
    
}
