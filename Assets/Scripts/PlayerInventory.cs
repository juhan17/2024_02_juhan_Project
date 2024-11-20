using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private SurvivalStats survivalStats;

    public int crystalCount = 0;
    public int caveCount = 0;
    public int bushCount = 0;

    public void Start()
    {
        survivalStats = GetComponent<SurvivalStats>();
    }

    public void UseItem(ItemType itemType)
    {
        if (GetItemCount(itemType) <= 0)
        {
            return;
        }

        switch (itemType)
        {
            case ItemType.VegetableStew:
                Removeitem(ItemType.VegetableStew, 1);
                survivalStats.EatFood(RecipeList.KitChenRecipes[0].hungerRestoreAmount);
                break;
            case ItemType.FruitSalad:
                Removeitem(ItemType.FruitSalad, 1);
                survivalStats.EatFood(RecipeList.KitChenRecipes[1].hungerRestoreAmount);
                break;
            case ItemType.RepairKit:
                Removeitem(ItemType.RepairKit, 1);
                survivalStats.EatFood(RecipeList.WorkbenchRecipes[0].repairAmount);
                break;
        }
    }

    public void AddItem(ItemType itemType, int amount)
    {
        for(int i= 0; i < amount; i++)
        {
            AddItem(itemType);
        }
    }

    public void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++;
                Debug.Log($"크리스탈 획득! 현재 개수 :{crystalCount}");
                break;
            case ItemType.Cave:
                caveCount++;
                Debug.Log($"동굴 획득! 현재 개수 :{caveCount}");
                break;
            case ItemType.Bush:
                bushCount++;
                Debug.Log($"수풀 획득! 현재 개수 :{bushCount}");
                break;
        }
    }

    public bool Removeitem(ItemType itemType, int amount = 1)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"크리스탈 {amount} 사용! 현재 개수 :{crystalCount}");
                    return true;
                }
                break;
            case ItemType.Cave:
                if (caveCount >= amount)
                {
                    caveCount -= amount;
                    Debug.Log($"동굴 {amount} 사용! 현재 개수 :{caveCount}");
                    return true;
                }
                break;
            case ItemType.Bush:
                if (bushCount >= amount)
                {
                    bushCount -= amount;
                    Debug.Log($"수풀 {amount} 사용! 현재 개수 :{bushCount}");
                    return true;
                }
                break;
        }

        Debug.Log($"{itemType} 아이템이 부족합니다.");
        return false;
    }

    public int GetItemCount(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                return crystalCount;
            case ItemType.Bush:
                return bushCount;
            case ItemType.Cave:
                return caveCount;
            default:
                return 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }

    private void ShowInventory()
    {
        Debug.Log("====인벤토리====");
        Debug.Log($"크리스탈:{crystalCount}개");
        Debug.Log($"동굴:{caveCount}개");
        Debug.Log($"수풀:{bushCount}개");
        Debug.Log("================");
    }
}
