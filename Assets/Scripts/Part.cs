using UnityEngine;

public abstract class Part : MonoBehaviour
{
    public Player Player;
    
    // Attach to an attachment point.
    public abstract void Attach(Attachment attachment);
}