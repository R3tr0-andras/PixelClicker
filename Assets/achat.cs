using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achat : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private CursorChangerScript _cursorScript;

    [Header("L'amélioration est-elle déjà acheté ?\n")]
    [SerializeField] private bool _isBought;

    [Header("L'amélioration change-t-elle le curseur ?\n")]
    [SerializeField] private bool _cursorChanger;
    [SerializeField] private uint _lvlCursor;

    [Header("Textures")]
    [SerializeField] public Texture2D _item;
    [SerializeField] public Texture2D _bought;
    [SerializeField] public Texture2D _sold;

    void Start()
    {
        InitializeComponents();
    }

    void Update()
    {
        
    }
    public void OnClickButton()
    {
        if(_cursorChanger)
        {
            _cursorScript.ChangeCursor(_lvlCursor);
        }
        
    }
    void InitializeComponents()
    {
        if (_item != null && _bought != null && _sold != null)
        {
            return;
        } else
        {
            Debug.Log("qqch est vide ici");
            return;
        }

    }
}
