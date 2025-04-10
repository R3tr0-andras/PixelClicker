using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

    // SCRIPTS
    public Click clickScript;

    // ATTRIBUTES
    public string name;

    public int numberOfUpgrades;
    public int price;
    public float multiplier;

    [Header("Automated")]
    public bool isAutomated = true;
    public int autoIncrement = 0;
    public int incrementBonus; // Nombre ajouté à l'autoIncrement lors de l'amélioration

    // GUI
    private TextMeshProUGUI buttonText;
    private TextMeshProUGUI buttonCPS;

    // Start is called before the first frame update
    void Start()
    {
        buttonText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (isAutomated) { buttonCPS = transform.GetChild(1).GetComponent<TextMeshProUGUI>(); }
        numberOfUpgrades = 0;
        UpdateText();
        
    }

    public void UpdateText()
    {
        buttonText.text = name + " (" + numberOfUpgrades + ")\nPrice: " + price;
        if (isAutomated) { buttonCPS.text = autoIncrement + " CPS"; }
        clickScript.UpdateScoreText();
    }
    public virtual void Click()
    {
        if (!(clickScript.score >= price)) return;

        clickScript.score -= price; // Soustrait le prix du score
        numberOfUpgrades++; // Augmente le nombre de cet upgrade
        price = (int)MathF.Round(price*multiplier); // Actualise le prix (prix * multipier) arroundi
        
        // Not Automated
        if (!isAutomated)
        {
            clickScript.increment++; // Augmente l'incrément par click
            UpdateText();
            return;
        }
        
        // Automated
        if(autoIncrement == 0)
        {
            StartCoroutine(AutomatedClick());
        }
        autoIncrement += incrementBonus;

        UpdateText();
        return;

    }

    IEnumerator AutomatedClick()
    {
        while (true)
        {
            Debug.Log(autoIncrement);
            yield return new WaitForSeconds(1);
            clickScript.score += autoIncrement;
            clickScript.UpdateScoreText();
        }

    }

}
