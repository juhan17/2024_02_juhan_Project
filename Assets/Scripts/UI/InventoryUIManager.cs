using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public static InventoryUIManager Instance { get; private set; }

    [Header("UI References")]
    public GameObject inventoryPanel;
    public Transform itemContainer;
    public GameObject itemSlotPrefab;
    public RecipeButton closeButton;

    private PlayerInventory playerInventory;
    private SurvivalStats survivalStats;

    private void Awake()
    {
        Instance = this;
        inventoryPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        survivalStats = FindObjectOfType<SurvivalStats>();
        //closeButton.onClick.AddListener(HideUI);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryPanel.activeSelf)
            {
                HideUI();
            }
            else
            {
                ShowUI();
            }
        }
    }

    public void ShowUI()
    {
        inventoryPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        RefreshInventory();
    }

    public void HideUI()
    {
        inventoryPanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RefreshInventory()
    {
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }
        CreateItemSlot(ItemType.Crystal);
        CreateItemSlot(ItemType.Cave);
        CreateItemSlot(ItemType.Bush);
        CreateItemSlot(ItemType.VegetableStew);
        CreateItemSlot(ItemType.FruitSalad);
        CreateItemSlot(ItemType.RepairKit);
    }

    private void CreateItemSlot(ItemType type)
    {
        GameObject slotObj = Instantiate(itemSlotPrefab, itemContainer);
        ItemSlot slot = slotObj.GetComponent<ItemSlot>();
        slot.Setup(type, playerInventory.GetItemCount(type));
    }
}
