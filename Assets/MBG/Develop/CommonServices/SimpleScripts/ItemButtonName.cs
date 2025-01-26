using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

public enum ingridType
{
    Soap,
    Liquid,
    Undefined
}

public class ItemButtonName : MonoBehaviour
{
    private UIManager uiManager;
    public ingridType type;

    public string Name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        uiManager = GameObject.FindWithTag("uiManager").GetComponent<UIManager>();

    }

    public void SendString()
    {
        ItemButtonName nameScript = GetComponent<ItemButtonName>();

        if (type == ingridType.Liquid)
        {
            uiManager.durSlider.value = Random.Range(1, 10);
        }

        if (type == ingridType.Soap)
        {
            uiManager.respSlider.value = Random.Range(1, 10); ;
        }

        switch (this.Name)
        {
            case "Water":
                Debug.Log("water");
                uiManager.AssingnMat(0);
                break;
            case "Cola":
                Debug.Log("cola");
                uiManager.AssingnMat(1);
                break;
            case "Oil":
                Debug.Log("oil");
                uiManager.AssingnMat(2);
                break;
            default:
                Debug.Log("Name not recognized.");
                break;
        }


        uiManager.mixerText.text = "";

        // Show info panel if no ingredients are present
        if (uiManager.ingidientsCount == 0)
        {
            uiManager.infoPanel.SetActive(true);
        }


        // Reset recipe text and ingredient count if the count reaches 2
        if (uiManager.ingidientsCount == 2)
        {
            uiManager.recipeText.text = "";
            uiManager.ingidientsCount = 0;
            uiManager.ingridTypeSave = ingridType.Undefined;
        }



        // Update the recipe text with the current ingredient
        if(uiManager.ingridTypeSave != this.type)
            uiManager.recipeText.text += nameScript.Name;

        uiManager.ingridTypeSave = this.type;

        // Append " and " if it's the first ingredient
        if (uiManager.ingidientsCount == 0)
        {
            uiManager.recipeText.text += " and ";
        }

        // Increment the ingredient count
        uiManager.ingidientsCount++;

    }
}
