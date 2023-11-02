using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get 
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is Null");
            }

            return _instance; 
        }
    }

    public TMP_Text playerGemCountText;

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount.ToString() + " G";
    }




    private void Awake()
    {
        _instance= this;
    }

}
