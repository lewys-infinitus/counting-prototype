using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphereSpawner : MonoBehaviour
{
    public GameObject largeSpherePrefab;  // Prefab for large spheres
    public GameObject mediumSpherePrefab; // Prefab for medium spheres
    public GameObject smallSpherePrefab;  // Prefab for small spheres

    private int totalLargeSpheres;  // Track total large spheres spawned
    private int totalMediumSpheres; // Track total medium spheres spawned
    private int totalSmallSpheres;  // Track total small spheres spawned

    public TextMeshProUGUI largeSphereText;  // UI Text element for large spheres count
    public TextMeshProUGUI mediumSphereText; // UI Text element for medium spheres count
    public TextMeshProUGUI smallSphereText;  // UI Text element for small spheres count

    void Start()
    {
        // Generate random counts between 0 and 15 for each type of sphere
        int largeSphereCount = Random.Range(0, 16);
        int mediumSphereCount = Random.Range(0, 16);
        int smallSphereCount = Random.Range(0, 16);

        // Spawn large, medium, and small spheres
        StartCoroutine(SpawnSpheres(largeSpherePrefab, largeSphereCount, totalLargeSpheres, largeSphereText, "Large Spheres"));
        StartCoroutine(SpawnSpheres(mediumSpherePrefab, mediumSphereCount, totalMediumSpheres, mediumSphereText, "Medium Spheres"));
        StartCoroutine(SpawnSpheres(smallSpherePrefab, smallSphereCount, totalSmallSpheres, smallSphereText, "Small Spheres"));
    }

    IEnumerator SpawnSpheres(GameObject spherePrefab, int count, int totalCount, TextMeshProUGUI display, string name)
    {
        for (int i = 0; i < count; i++)
        {
            // Generate a random x position within the range
            float randomX = Random.Range(-3f, 3f);

            // Set the spawn position
            Vector3 spawnPosition = new Vector3(randomX, 18f, 5f);

            // Instantiate the sphere prefab at the random position
            Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

            // Increment the total count of spheres
            totalCount++;

            // Update the UI Text element with the total count
            display.text = $"{name} {totalCount}";

            yield return new WaitForSeconds(0.5f);
        }
    }
}
