using Interactables;
using UnityEngine;

public class SwitchTester : MonoBehaviour
{
    public Switch Switch;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (Switch.IsOn)
            {
                Switch.Deactivate();
            }
            else
            {
                Switch.Activate();
            }
        }
    }
}