using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectableArm : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        Debug.Log("Arm found! Enabling it now.");
        player.EnableArm();
        Destroy(gameObject);
    }
}
