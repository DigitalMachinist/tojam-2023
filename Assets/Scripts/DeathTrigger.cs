using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeathTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var killable = other.GetComponent<Killable>();
        if (killable == null)
        {
            return;
        }
        
        Debug.Log("Killing " + killable.Movable.name);
        killable.Kill();
    }
}