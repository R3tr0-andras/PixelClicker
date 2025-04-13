using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    public bool isInGame;
    public int niveau;
    public Texture2D[] curseurs;
    public Texture2D curseurBasic;
    // Start is called before the first frame update
    void Start()
    {
        isInGame = true;
        ChangeCursor();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCursor();
    }

    void ChangeCursor()
    {
        if (!isInGame) // Pour afficher le curseur en pioche et pas en main
        {
            if (niveau >= 0 && niveau < curseurs.Length)
            {
                Cursor.SetCursor(curseurs[niveau], Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Debug.LogWarning("Niveau invalide pour changer le curseur");
            }
        } else
        {
            Cursor.SetCursor(curseurBasic, Vector2.zero, CursorMode.Auto);
        }
    }
}
