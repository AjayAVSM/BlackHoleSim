using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EncyclopaediaManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject buttonsList;   // The scrollable list of buttons
    public GameObject entryPanel;    // The detail panel
    public ScrollRect scrollRect;   // The ScrollRect

    [Header("Entry UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI formulaTitleText;
    public Image formulaImageUI;
    public Image realImageUI;
    public Image simImageUI;
    public TextMeshProUGUI tryText;

    // Called when a button is pressed
    public void OpenEntry(EncyclopaediaEntry entry)
    {
        // Hide list, show entry panel
        buttonsList.SetActive(false);
        entryPanel.SetActive(true);

        // Fill UI from the ScriptableObject
        titleText.text = entry.title;
        descriptionText.text = entry.description;
        tryText.text = entry.tryItOutDescription;
        formulaTitleText.text = entry.formulaTitle;

        // Formula image
        if (entry.formulaImage != null)
        {
            formulaImageUI.sprite = entry.formulaImage;
            formulaImageUI.gameObject.SetActive(true);
        }
        else
        {
            formulaImageUI.gameObject.SetActive(false);
        }

        // Real image
        if (entry.realImage != null)
        {
            realImageUI.sprite = entry.realImage;
            realImageUI.gameObject.SetActive(true);
        }
        else
        {
            realImageUI.gameObject.SetActive(false);
        }

        // Simulation image
        if (entry.simImage != null)
        {
            simImageUI.sprite = entry.simImage;
            simImageUI.gameObject.SetActive(true);
        }
        else
        {
            simImageUI.gameObject.SetActive(false);
        }

        // Reset scroll to top
        scrollRect.verticalNormalizedPosition = 1f;

    }

    // Called when Back button is pressed
    public void BackToList()
    {
        entryPanel.SetActive(false);
        buttonsList.SetActive(true);
    }
}
