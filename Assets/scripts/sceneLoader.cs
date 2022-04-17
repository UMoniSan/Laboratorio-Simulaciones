using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void CambiarEscena(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

}
