using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{

    [SerializeField] private DialogNodeGraph dialogGraph;
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private GameObject playerObj;
    private bool firstTalk = true;
    public GameObject Canvas;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == playerObj && firstTalk == true)
        {
            Debug.Log("Collosion Succesfull");
            Dialog();
            firstTalk = false;
        }
    }

    void Dialog()
    {
        Canvas.SetActive(true);
        dialogBehaviour.StartDialog(dialogGraph);
    }
}
