public class Arm : Part
{
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Attachment = Player.ArmAttachment;
        Player.ArmPlaced += OnArmPlaced;
        Player.ArmRecalled += OnArmRecalled;
        Player.GrabStarted += OnGrabStarted;
        Player.GrabEnded += OnGrabEnded;
        Player.InteractStarted += OnInteractStarted;
        Player.InteractEnded += OnInteractEnded;
    }

    void OnArmPlaced()
    {
        throw new System.NotImplementedException();
    }

    void OnArmRecalled()
    {
        throw new System.NotImplementedException();
    }

    void OnGrabStarted()
    {
        throw new System.NotImplementedException();
    }

    void OnGrabEnded()
    {
        throw new System.NotImplementedException();
    }

    void OnInteractStarted()
    {
        throw new System.NotImplementedException();
    }

    void OnInteractEnded()
    {
        throw new System.NotImplementedException();
    }

    public override void Attach(Attachment attachment)
    {
        throw new System.NotImplementedException();
    }
}