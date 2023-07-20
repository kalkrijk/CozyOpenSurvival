using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{

    [SerializeField] private DialogNodeGraph dialogGraph;
    [SerializeField] private DialogBehaviour dialogBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        dialogBehaviour.StartDialog(dialogGraph);
    }

}
