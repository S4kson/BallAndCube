using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject[] objects = new GameObject[3];
    public Transform[] transforms = new Transform[3];
    public float speed = 5.0f, rotateSpeed = 10.0f;
    public Transform targets;
    public BoxCollider box;
    public Light light;

    private void Start()
    {
        //cube.SetActive(false);
        //cube.GetComponent<Transform>().position = new Vector3(10, 0, 5);
        //targets.position = new Vector3(10, 0, 5);
        //light.intensity = 0.5f;

        //for (int i = 0; i < objects.Length; i++)
        //{
        //    objects[i].SetActive(false);
        //}
    }

    private void Update()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i] == null)
                continue;
             
            transforms[i].Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            transforms[i].Rotate(new Vector3(-1, 0, 0) * rotateSpeed * Time.deltaTime);

            float posX = transforms[i].position.x;
            if (posX < -10f && transforms[i].gameObject.name == "Cube")
                Destroy(transforms[i].gameObject);
            

        }
    }
}
