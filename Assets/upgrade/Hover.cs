using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject infoPanel; // Le panneau � afficher
    public Vector2 offset = new Vector2(10f, -10f);
    private bool pointerOverTarget = false;
    private bool pointerOverPanel = false;
    void Start()
    {
        if (infoPanel != null)
        {
            // S'assurer que le panneau est cach� au d�part
            infoPanel.SetActive(false);

            // Ajouter automatiquement le d�clencheur sur le panneau
            AddEventTrigger(infoPanel);
        }
    }

    void Update()
    {
        if ((pointerOverTarget || pointerOverPanel) && infoPanel != null)
        {
            Vector2 mousePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                infoPanel.transform.parent as RectTransform,
                Input.mousePosition,
                null,
                out mousePos
            );
            infoPanel.GetComponent<RectTransform>().anchoredPosition = mousePos + offset;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerOverTarget = true;
        ShowPanel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerOverTarget = false;
        Invoke(nameof(HidePanelIfNeeded), 0.1f); // Petit d�lai pour v�rifier
    }

    private void AddEventTrigger(GameObject panel)
    {
        EventTrigger trigger = panel.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = panel.AddComponent<EventTrigger>();
        }

        // Enter
        EventTrigger.Entry entryEnter = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        entryEnter.callback.AddListener((eventData) => { pointerOverPanel = true; });
        trigger.triggers.Add(entryEnter);

        // Exit
        EventTrigger.Entry entryExit = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerExit
        };
        entryExit.callback.AddListener((eventData) => {
            pointerOverPanel = false;
            Invoke(nameof(HidePanelIfNeeded), 0.1f);
        });
        trigger.triggers.Add(entryExit);
    }

    private void ShowPanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);
    }

    private void HidePanelIfNeeded()
    {
        if (!pointerOverTarget && !pointerOverPanel && infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
