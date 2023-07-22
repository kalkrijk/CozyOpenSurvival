using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{

    [SerializeField] private DialogNodeGraph dialogGraph;
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject interactText;
    [SerializeField] private bool canTalk;
    private bool firstTalk = true;
    public GameObject Canvas;
    public KeyCode interactKey = KeyCode.E;
    // Start is called before the first frame update

    private void Update()
    {
        InteractLogic();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != playerObj)
        {
            return;
        }
        else
        {
            interactText.SetActive(true);
            canTalk = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerObj)
        { 
            interactText.SetActive(false);
            canTalk = false;
        }
    }
    void Dialog()
    {
        Canvas.SetActive(true);
        dialogBehaviour.StartDialog(dialogGraph);
        firstTalk = false;
    }
    void InteractLogic()
    {
        if(canTalk && Input.GetKeyDown(interactKey) && firstTalk)
        {
            Dialog();
        }
    }
}
