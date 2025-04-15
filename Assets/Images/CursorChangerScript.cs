using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChangerScript : MonoBehaviour
{
    public bool isInGame;
    public uint niveau;
    public Texture2D[] curseurs = new Texture2D[7];
    public Texture2D curseurBasic;
    void Start()
    {
        isInGame = true;

        if (curseurs != null && curseurs.Length > 0)
        {
            curseurs = ConvertAllToCursorCompatible(curseurs);
        }
        else
        {
            Debug.LogWarning("Aucune texture de curseur trouvée.");
        }

        if (curseurBasic != null)
        {
            curseurBasic = ConvertToCursorCompatible(curseurBasic);
        }

        ChangeCursor(niveau);
    }
    void Update()
    {
        //ChangeCursor();
    }

    public void ChangeCursor(uint lvl)
    {
        if (!isInGame)
        {
            if (curseurs != null && niveau >= 0 && niveau < curseurs.Length && curseurs[niveau] != null)
            {
                Cursor.SetCursor(curseurs[lvl], Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Debug.LogWarning("Niveau invalide ou texture curseur manquante");
            }
        }
        else
        {
            if (curseurBasic != null)
            {
                Cursor.SetCursor(curseurBasic, Vector2.zero, CursorMode.Auto);
            }
        }
    }
    /// <summary>
    /// Converti les textures 16x16px (une par une)
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    Texture2D ConvertToCursorCompatible(Texture2D original)
    {
        // Crée une nouvelle texture avec les bonnes spécifications
        Texture2D converted = new Texture2D(original.width, original.height, TextureFormat.RGBA32, false);

        // Copie les pixels
        converted.SetPixels(original.GetPixels());
        converted.Apply();

        return converted;
    }
    /// <summary>
    /// Converti les textures 16x16px (le tableau entier)
    /// </summary>
    /// <param name="originals"></param>
    /// <returns></returns>
    Texture2D[] ConvertAllToCursorCompatible(Texture2D[] originals)
    {
        Texture2D[] convertedArray = new Texture2D[originals.Length];

        for (int i = 0; i < originals.Length; i++)
        {
            if (originals[i] != null)
            {
                convertedArray[i] = ConvertToCursorCompatible(originals[i]);
            }
            else
            {
                Debug.LogWarning("Texture manquante à l'index " + i);
            }
        }

        return convertedArray;
    }
}
