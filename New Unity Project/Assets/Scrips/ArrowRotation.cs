using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    private GameObject mainCamera;
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        ArrorAngel();
    }

    private void ArrorAngel()
    {
        transform.rotation = mainCamera.transform.rotation;
    }
}
