using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [Header("Scripts")]
    public Click clickScript;

    [Header("Attributes")]
    public string _name;
    public int _Upgrade;
    public int _unlockPrice;
    public int _price;
    public float _multiplierFactor = 1.5f;

    [Header("Automated")]
    public bool _isUnlocked = false;
    public bool _isAutomated = true;
    public float _autoIncrement = 0;

    [Header("GUI")]
    public TextMeshProUGUI _nameTextMesh;
    public TextMeshProUGUI _lvlTextMesh;
    public TextMeshProUGUI _priceTextMesh;
    public TextMeshProUGUI _CPSTextMesh;
    public GameObject actionButton; 
    private Button buttonComponent; 

    private float _timer;

    void Start()
    {
        buttonComponent = actionButton.GetComponent<Button>();
        UpdateUI();
        UpdateButtonState(); 
    }

    void Update()
    {
        if (_isUnlocked && _isAutomated)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1f)
            {
                clickScript.AddScore(_autoIncrement); 
                _timer = 0f;
            }
        }
        UpdateButtonState(); 
    }

    private void UpdateButtonState()
    {
        if (!_isUnlocked)
        {
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unlock: " + _unlockPrice;
            actionButton.SetActive(true); 
            buttonComponent.interactable = clickScript.GetScore() >= _unlockPrice;

            if (clickScript.GetScore() < _unlockPrice)
            {
                buttonComponent.GetComponent<Image>().color = Color.red; // Change la couleur en rouge
            }
            else
            {
                buttonComponent.GetComponent<Image>().color = Color.white; // Rétablir la couleur normale
            }
        }
        else
        {
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade: " + _price;
            actionButton.SetActive(true); 

            if (_Upgrade >= 20)
            {
                buttonComponent.interactable = false; // Désactive l'interaction
                buttonComponent.GetComponent<Image>().color = Color.yellow; // Change la couleur en jaune
                _priceTextMesh.text =""; // Enlevé le prix
            }
            else
            {
                buttonComponent.interactable = clickScript.GetScore() >= _price;

                if (clickScript.GetScore() < _price)
                {
                    buttonComponent.GetComponent<Image>().color = Color.red; // Change la couleur en rouge
                }
                else
                {
                    buttonComponent.GetComponent<Image>().color = Color.white; // Rétablir la couleur normale
                }
            }
        }
    }
    public void OnActionButtonClick()
    {
        if (!_isUnlocked && clickScript.GetScore() >= _unlockPrice)
        {
            TryUnlock();
        }
        else if (_isUnlocked && clickScript.GetScore() >= _price && _Upgrade < 20)
        {
            TryUpgrade();
        }
    }
    public void TryUnlock()
    {
        clickScript.RemoveScore(_unlockPrice);
        _isUnlocked = true;
        _Upgrade = 1;
        UpdateUI();
    }
    public void TryUpgrade()
    {
        clickScript.RemoveScore(_price);
        _Upgrade++;
        _autoIncrement += CalculateAutoIncrement();
        _price = Mathf.RoundToInt(_price * _multiplierFactor);
        clickScript.AddClickCount(1);
        UpdateUI();
    }

    private float CalculateAutoIncrement()
    {
        return 1f;
    }

    private void UpdateUI()
    {
        _nameTextMesh.text = _name;
        _lvlTextMesh.text = "lvl : " + _Upgrade;
        _priceTextMesh.text = "Price : " + _price;
        _CPSTextMesh.text = "CPS : " + Mathf.RoundToInt(_autoIncrement).ToString();
    }
}
