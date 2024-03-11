using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingCrops : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] imagePrefabs;
    private Transform imagesParent;
    private GameObject[] imageInstances;
    private int currentIndex = 0;

    void Start()
    {
        // Instantiate child images from the prefabs
        InstantiateImages();

        // Set initial visibility
        SetVisibility();

        // Start a coroutine for sequential visibility changes
        StartCoroutine(SequentiallyChangeVisibility());
    }

    void InstantiateImages()
    {
        imagesParent = new GameObject("ImagesParent").transform;
        imagesParent.SetParent(transform);

        // Instantiate child images from the prefabs
        imageInstances = new GameObject[imagePrefabs.Length];

        for (int i = 0; i < imageInstances.Length; i++)
        {
            imageInstances[i] = Instantiate(imagePrefabs[i], imagesParent);
            imageInstances[i].SetActive(false);
        }
    }

    void SetVisibility()
    {
        // Show the first image
        imageInstances[currentIndex].SetActive(true);
    }

    System.Collections.IEnumerator SequentiallyChangeVisibility()
    {
        while (true)
        {
            // Hide all other images
            for (int i = 0; i < imageInstances.Length; i++)
            {
                if (i != currentIndex)
                {
                    imageInstances[i].SetActive(false);
                }
            }

            // Increment index
            currentIndex = (currentIndex + 1) % imageInstances.Length;

            // Show the next image
            imageInstances[currentIndex].SetActive(true);

            // Wait for 1 second (adjust as needed)
            yield return new WaitForSeconds(1f);
        }
    }
}