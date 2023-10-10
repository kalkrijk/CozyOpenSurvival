using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Barrel barrel = GetComponent<Barrel>();
        barrel.OnBarrelObliderated += Barrel_OnBarrelObliderated;
    }

    private void Barrel_OnBarrelObliderated(object sender, System.EventArgs e)
    {
        Debug.Log("You feel a chill going up you're spine");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
