using UnityEngine;

public abstract class Part : MonoBehaviour
{
    public Player Player;
    public Attachment Attachment;
    
    // Attach to an attachment point.
    public abstract void Attach(Attachment attachment);
}