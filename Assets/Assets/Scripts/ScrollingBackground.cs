using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public float backgroundSize;
    public float viewZone;
    public float paralaxSpeed;
    public float unpausedSpeed;

    private Transform cameraTransform;
    private Transform[] layers;
    private int leftIndex;
    private int rightIndex;   

    public void Start()
    {
        cameraTransform = Camera.main.transform;        
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        //float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (paralaxSpeed);        

        if (cameraTransform.position.x > (layers[leftIndex].transform.position.x - viewZone))
        {
            ScrollRight();
        }
    }

    private void ScrollRight()
    {
        //int lastLeft = leftIndex;
        layers[leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize, layers[rightIndex].position.y, layers[rightIndex].position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }

    //private void ScrollLeft(float deltaX)
    //{
    //    int lastRight = rightIndex;
    //    layers[rightIndex].position = new Vector3(layers[leftIndex].position.x - backgroundSize, layers[leftIndex].position.y, layers[leftIndex].position.z);
    //    leftIndex = rightIndex;
    //    rightIndex--;
    //    if (rightIndex < 0)
    //    {
    //        rightIndex = layers.Length - 1;
    //    }
    //}
}
