public class Leg : Part
{
    void Start()
    {
        Player.Jumped += OnJumped;
        Player.Kicked += OnKicked;
        Player.LegPlaced += OnLegPlaced;
        Player.LegRecalled += OnLegRecalled;
    }

    void OnJumped()
    {
        throw new System.NotImplementedException();
    }

    void OnKicked()
    {
        throw new System.NotImplementedException();
    }

    void OnLegPlaced()
    {
        throw new System.NotImplementedException();
    }

    void OnLegRecalled()
    {
        throw new System.NotImplementedException();
    }

    public override void Attach(Attachment attachment)
    {
        throw new System.NotImplementedException();
    }
}