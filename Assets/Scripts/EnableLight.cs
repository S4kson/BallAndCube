using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLight : MonoBehaviour
{
    public Light mainLight;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            mainLight.enabled = !mainLight.enabled ;
        }
    }
}
