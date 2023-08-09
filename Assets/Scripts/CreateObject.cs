using System;
using System.Collections;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
            StartCoroutine(Create3dObjects(2f));
        //Invoke("Create", 2f);
    }

    public GameObject[] Object;
    private void Create()
    {
        for (int i = 0; i < 5; i++)
        {
            //GameObject newObject = Instantiate(Object, new Vector3(0,5,0), Quaternion.Euler(12f, -15f, 40f)) as GameObject;
            //newObject.GetComponent<Transform>().position = new Vector3(5,5,0);
            Instantiate(Object[UnityEngine.Random.Range(0, Object.Length)], new Vector3(RandomNumber(), RandomNumber(), RandomNumber()), Quaternion.Euler(RandomNumber(), -15f, 40f));
        }
    }
    private int RandomNumber()
    {
        return UnityEngine.Random.Range(0, 10);
    }
    private IEnumerator Create3dObjects(float wait)
    {
        while (true)
        {
            Instantiate(Object[UnityEngine.Random.Range(0, Object.Length)], new Vector3(RandomNumber(), RandomNumber(), RandomNumber()), Quaternion.Euler(RandomNumber(), -15f, 40f));
            yield return new WaitForSeconds(wait);
        }
    }
}
