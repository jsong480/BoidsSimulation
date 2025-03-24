using System.Collections.Generic;
using UnityEngine;

public class ClickSpawner : MonoBehaviour
{
    public Camera cam;
    public float spawnOffset = 0.2f;
    public List<GameObject> geometryPrefabs;
    public GameObject previewPrefab;

    private GameObject previewInstance;

    void Start()
    {
        previewInstance = Instantiate(previewPrefab);
        previewInstance.SetActive(false);
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.CompareTag("TopFace"))
            {
                previewInstance.SetActive(true);
                Vector3 previewPos = hit.point + Vector3.up * 0.01f;
                previewInstance.transform.position = previewPos;


                if (Input.GetMouseButtonDown(0))
                {

                    Vector3 spawnPos = hit.point - Vector3.up * spawnOffset;

                    if (geometryPrefabs.Count > 0)
                    {
                        GameObject prefab = geometryPrefabs[Random.Range(0, geometryPrefabs.Count)];
                        Instantiate(prefab, spawnPos, Quaternion.identity);
                    }
                }
            }
        }
    }
}