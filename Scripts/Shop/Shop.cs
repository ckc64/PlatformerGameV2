using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if(player != null)
            {
                UIManager.Instance.OpenShop(player.totalDiamonds);
            }
            shopPanel.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void selectItem(int selectedItem)
    {
        switch (selectedItem)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(334);
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(223);
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(114);
                break;
        }
    }
}
