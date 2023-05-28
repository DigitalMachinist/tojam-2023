using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTrigger : MonoBehaviour
{
    public string SceneName;
    
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        Debug.Log("Loading scene " + SceneName);
        SceneManager.LoadScene(SceneName);
    }
}
