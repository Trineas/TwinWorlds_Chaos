using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public string sceneToLoad;

    IEnumerator LevelResetCo()
    {
        PlayerController.instance.stopMove = true;
        MouseLook.instance.stopLook = true;
        UIManager.instance.fadeToBlack = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LevelResetCo());
        }
    }
}
