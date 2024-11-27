using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;
    private Vector3 lastPosition;
    private float moveThreshold = 0.1f;
    private ConstructibleBuilding currentNearbyBuilding;
    private BuildingCrafter currentBuildingCrafter;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        CheckForBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastPosition, transform.position) > moveThreshold)
        {
            CheckForBuilding();
            lastPosition = transform.position;
        }

        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            if(!currentNearbyBuilding.isConstructed)
            {
                currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());
            }
            else if(currentBuildingCrafter != null)
            {
                Debug.Log($"{currentNearbyBuilding.buildingName}의 제작 메뉴 열기");
                CraftingUIManager.Instance?.ShowUI(currentBuildingCrafter);
            }
        }
    }

    private void CheckForBuilding()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        float closestDistance = float.MaxValue;
        ConstructibleBuilding closestBuilding = null;
        BuildingCrafter closestCrafter = null;

        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();
            if (building != null)
            {
                float distance = Vector3.Distance(transform.position, building.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestBuilding = building;
                    closestCrafter = building.GetComponent<BuildingCrafter>();
                }
            }
        }

        if (closestBuilding != currentNearbyBuilding)
        {
            currentNearbyBuilding = closestBuilding;
            currentBuildingCrafter = closestCrafter;

            if (currentNearbyBuilding != null && !currentNearbyBuilding.isConstructed)
            {
                if (FloatingTextManager.Instance != null)
                {
                    FloatingTextManager.Instance.Show($"[F]키로 {currentNearbyBuilding.buildingName} 건설 (동굴 {currentNearbyBuilding.requiredCave} 개 필요)",
                    currentNearbyBuilding.transform.position + Vector3.up);
                }
            }
        }
    }
}
