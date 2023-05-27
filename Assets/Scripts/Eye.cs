public class Eye : Part
{ 
    void Start()
    {
        Player = FindObjectOfType<Player>();
        Attachment = Player.EyeAttachment;
        Player.EyePlaced += OnEyePlaced;
        Player.EyeRecalled += OnEyeRecalled;
        Player.LaserStarted += OnLaserStarted;
        Player.LaserEnded += OnLaserEnded;
    }

    void OnEyePlaced()
    {
        throw new System.NotImplementedException();
    }

    void OnEyeRecalled()
    {
        throw new System.NotImplementedException();
    }

    void OnLaserStarted()
    {
        throw new System.NotImplementedException();
    }

    void OnLaserEnded()
    {
        throw new System.NotImplementedException();
    }

    public override void Attach(Attachment attachment)
    {
        throw new System.NotImplementedException();
    }
}