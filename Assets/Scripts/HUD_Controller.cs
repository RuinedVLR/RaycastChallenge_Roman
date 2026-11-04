using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;
    public TMP_Text dialogueText;

    private void Start()
    {
        interactionText.text = "";
        dialogueText.text = "";
    }

    public void EnableInteractionText(string text)
    {
        interactionText.text = $"{PlayerInteraction.instance.currentInteractable.objectName}: {text} (E)";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}