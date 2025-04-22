using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class achat : MonoBehaviour
{
    [Header("Références")]
    public Click clickScript;

    [Header("Données de l'amélioration")]
    public int unlockPrice = 100;
    public float clickPowerBonus = 2f;

    [Header("UI")]
    public TextMeshProUGUI priceText;
    public Button unlockButton;
    public GameObject panelToHide; // Le GameObject à désactiver après achat (bouton, UI, etc.)

    private bool isUnlocked = false;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (!isUnlocked)
        {
            unlockButton.interactable = clickScript.GetScore() >= unlockPrice;
            unlockButton.GetComponent<Image>().color = unlockButton.interactable ? Color.white : Color.red;
        }
    }

    public void OnUnlockClick()
    {
        if (isUnlocked) return;

        if (clickScript.GetScore() >= unlockPrice)
        {
            clickScript.RemoveScore(unlockPrice);
            clickScript.AddClickPower(clickPowerBonus);

            isUnlocked = true;

            // Cache l'objet (désactive le panneau ou le bouton)
            if (panelToHide != null)
                panelToHide.SetActive(false);
        }
    }

    void UpdateUI()
    {
        if (priceText != null)
        {
            priceText.text = "Unlock: " + unlockPrice;
        }
    }
}
