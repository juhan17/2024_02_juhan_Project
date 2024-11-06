using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int crystalCount = 0;
    public int caveCount = 0;
    public int bushCount = 0;

    public void AddItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++;
                Debug.Log($"Å©¸®½ºÅ» È¹µæ! ÇöÀç °³¼ö :{crystalCount}");
                break;
            case ItemType.Cave:
                caveCount++;
                Debug.Log($"µ¿±¼ È¹µæ! ÇöÀç °³¼ö :{caveCount}");
                break;
            case ItemType.Bush:
                bushCount++;
                Debug.Log($"¼öÇ® È¹µæ! ÇöÀç °³¼ö :{bushCount}");
                break;
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
        Debug.Log("====ÀÎº¥Åä¸®====");
        Debug.Log($"Å©¸®½ºÅ»:{crystalCount}°³");
        Debug.Log($"µ¿±¼:{caveCount}°³");
        Debug.Log($"¼öÇ®:{bushCount}°³");
        Debug.Log("================");
    }
}
