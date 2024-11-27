using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCrafter : MonoBehaviour
{
    public BuildingType buildingType;
    public CraftingRecipe[] recipes;
    private SurvivalStats survivalStats;
    private ConstructibleBuilding building;


    // Start is called before the first frame update
    void Start()
    {
        survivalStats = FindObjectOfType<SurvivalStats>();
        building = GetComponent <ConstructibleBuilding>();

        switch(buildingType)
        {
            case BuildingType.Kitchen:
                recipes = RecipeList.KitChenRecipes;
                break;
            case BuildingType.CraftingTable:
                recipes = RecipeList.WorkbenchRecipes;
                break;
        }
    }

    public void TryCraft(CraftingRecipe recipe, PlayerInventory inventory)
    {
        if(!building.isConstructed)
        {
            FloatingTextManager.Instance?.Show("�Ǽ��� �Ϸ� ���� �ʾҽ��ϴ�!", transform.position + Vector3.up);
            return;
        }

        for (int i = 0; i < recipe.requiredItems.Length; i++)
        {
            if (inventory.GetItemCount(recipe.requiredItems[i]) < recipe.requiredAmounts[i])
            {
                FloatingTextManager.Instance?.Show("��ᰡ �����մϴ�. !", transform.position + Vector3.up);
                return;
            }
        }

        for (int i = 0; i < recipe.requiredItems.Length; i++)
        {
            inventory.Removeitem(recipe.requiredItems[i], recipe.requiredAmounts[i]);
        }

        survivalStats.DamageOnCrafting();

        inventory.AddItem(recipe.resultItem , recipe.resultAmount);
        FloatingTextManager.Instance?.Show($"{recipe.itemName} ���� �Ϸ�!", transform.position + Vector3.up);
    }

}
