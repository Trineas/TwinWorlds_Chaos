using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EngineTransition : MonoBehaviour
{
    public string applicationName;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(OpenApplicationCo());
        }
    }

    IEnumerator OpenApplicationCo()
    {
        MouseLook.instance.stopLook = true;
        PlayerController.instance.stopMove = true;
        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(2f);
        Application.Quit();
        Process.Start(applicationName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(OpenApplicationCo());
        }
    }
}
