using AlignedGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructibleBuilding : MonoBehaviour
{
    [Header("Building Seeting")]
    public BuildingType buildingType;
    public string buildingName;
    public int requiredCave = 5;
    public float constructionTime = 2.0f;

    public bool canBuild = true;
    public bool isConstructed = false;

    private Material buildingMaterial;

    // Start is called before the first frame update
    void Start()
    {
        buildingMaterial = GetComponent<MeshRenderer>().material;
        Color color = buildingMaterial.color;
        color.a = 0.5f;
        buildingMaterial.color = color;
    }

    public void StartConstruction(PlayerInventory inventory)
    {
        if (!canBuild || isConstructed) return;

        if (inventory.caveCount >= requiredCave)
        {
            inventory.Removeitem(ItemType.Cave, requiredCave);
            if (FloatingTextManager.Instance != null)
            {
                FloatingTextManager.Instance.Show($"{buildingName} �Ǽ� ����!", transform.position + Vector3.up);
            }
            StartCoroutine(ConstructionRoutine());
        }
        else
        {
            if (FloatingTextManager.Instance != null)
            {
                FloatingTextManager.Instance.Show($"������ �����մϴ�! ({inventory.caveCount} / {requiredCave})", transform.position + Vector3.up);
            }
        }
    }

    private IEnumerator ConstructionRoutine()
    {
        canBuild = false;
        float timer = 0;
        Color color = buildingMaterial.color;

        while (timer < constructionTime)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0.5f, 1f, timer / constructionTime);
            buildingMaterial.color = color;
            yield return null;
        }
        isConstructed = true;

        if(FloatingTextManager.Instance != null)
        {
            FloatingTextManager.Instance.Show($"{buildingName} �Ǽ� �Ϸ�!", transform.position + Vector3.up);
        }
    }


}
