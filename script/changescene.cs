using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene2 : MonoBehaviour
{
    public int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}