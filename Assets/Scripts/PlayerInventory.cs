using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int crystalCount = 0;
    public int caveCount = 0;
    public int bushCount = 0;

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
                Debug.Log($"ũ����Ż ȹ��! ���� ���� :{crystalCount}");
                break;
            case ItemType.Cave:
                caveCount++;
                Debug.Log($"���� ȹ��! ���� ���� :{caveCount}");
                break;
            case ItemType.Bush:
                bushCount++;
                Debug.Log($"��Ǯ ȹ��! ���� ���� :{bushCount}");
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
                    Debug.Log($"ũ����Ż {amount} ���! ���� ���� :{crystalCount}");
                    return true;
                }
                break;
            case ItemType.Cave:
                if (caveCount >= amount)
                {
                    caveCount -= amount;
                    Debug.Log($"���� {amount} ���! ���� ���� :{caveCount}");
                    return true;
                }
                break;
            case ItemType.Bush:
                if (bushCount >= amount)
                {
                    bushCount -= amount;
                    Debug.Log($"��Ǯ {amount} ���! ���� ���� :{bushCount}");
                    return true;
                }
                break;
        }

        Debug.Log($"{itemType} �������� �����մϴ�.");
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
        Debug.Log("====�κ��丮====");
        Debug.Log($"ũ����Ż:{crystalCount}��");
        Debug.Log($"����:{caveCount}��");
        Debug.Log($"��Ǯ:{bushCount}��");
        Debug.Log("================");
    }
}
