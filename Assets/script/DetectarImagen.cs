using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class DetectarImagen : MonoBehaviour
{
    private ARTrackedImageManager imageManager;



    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (var trackedImage in obj.added)
        {
            //do something
        }
    }

    void CheckImage(ARTrackedImage image)
    {
        //if(image.referenceImage.name 
        //    )
    }

    




}
