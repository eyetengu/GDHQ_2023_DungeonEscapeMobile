using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject _shopkeeperPanel;

    //TRADE BEHAVIORS


    //SHOP BEHAVIORS
    private void OpenShop()
    {
        _shopkeeperPanel.SetActive(true);
    }

    private void CloseUpShop()
    {
        _shopkeeperPanel.SetActive(false);
    }


    //TRIGGERS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }
            OpenShop();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
            CloseUpShop();
    }
}
