using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectableLeg : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();
        if (player == null)
        {
            return;
        }

        Debug.Log("Leg found! Enabling it now.");
        player.EnableLeg();
        Destroy(gameObject);
    }
}
