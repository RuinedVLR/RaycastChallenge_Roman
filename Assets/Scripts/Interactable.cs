using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Interactable : MonoBehaviour
{
    Outline outline;

    public string objectName;
    public string message;

    public UnityEvent onInteraction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OpenCloseDoor()
    {
        if(gameObject.transform.rotation.eulerAngles.y == 0)
        {
            gameObject.transform.Rotate(0, 90, 0);
            gameObject.transform.position += new Vector3(-1, 0, -0.5f);
        }
        else
        {
            gameObject.transform.Rotate(0, -90, 0);
            gameObject.transform.position += new Vector3(1, 0, 0.5f);
        }
    }

    public void TalkToNPC()
    {
        StopAllCoroutines();
        StartCoroutine(ShowDialogueText());
    }

    IEnumerator ShowDialogueText()
    {
        HUDController.instance.dialogueText.text = "Can't talk to this NPC right now. He is very busy!";
        yield return new WaitForSeconds(3);
        HUDController.instance.dialogueText.text = "";
    }
}