using System;
using System.Collections;
using System.Collections.Generic;
using ResourcesLoader;
using UnityEngine;

public class ExampleResource : MonoBehaviour
{
    private IEnumerator Start()
    {
        ResourcesLoad.Basic_Capsule.Instantiate(new Vector3(0,10,0));
        yield return new WaitForSeconds(1);
        ResourcesLoad.Basic_Cube.Instantiate(new Vector3(0,10,0));
    }
}
