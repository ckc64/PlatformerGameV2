using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("NULL UI Manager");
            }

            return instance;
        }
    }
    public Text playerGemCount;
    public Image selectionImage;
    public Text gemCountHUD;
    public Image[] lifeBars;

    public void OpenShop(int gemCount)
    {
        playerGemCount.text = gemCount.ToString() + "G";
    }

    public void UpdateShopSelection(int yPosition)
    {
        //to update the selection highlight based on user tap
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPosition);
    }

    public void UpdateGemCountHUD(int count)
    {
        gemCountHUD.text = count.ToString();
    }

    public void UpdateLifeUnits(int lifeUnitRemaining)
    {
        for(int i = 0; i <= lifeUnitRemaining; i++)
        {
            //count how many life remaining
            if(i == lifeUnitRemaining)
            {
                //hide the lifebar in the Game HUD
                lifeBars[i].enabled = false;
            }
        }
    }
   
    private void Awake()
    {
        instance = this;
    }
}
