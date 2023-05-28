using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public Player player;

    [Header("Eye UI")]
    public GameObject eyeUI;
    public GameObject eyeInUseUI;
    public GameObject eyeUnusableUI;

    [Header("Arm UI")]
    public GameObject armUI;
    public GameObject armInUseUI;
    public GameObject armUnusableUI;

    [Header("Leg UI")]
    public GameObject legUI;
    public GameObject legInUseUI;
    public GameObject legUnusableUI;

    void Start()
    {

        // ARM Section

        if (!player.HasArm)
        {
            DisableArm();
        }
        else
        {
            EnableArm();
        }

        player.ArmEnabled += EnableArm;
        player.ArmPlaced += ArmInUse;
        player.ArmRecalled += RecallArm;

        // Eye Section

        if (!player.HasEye)
        {
            DisableEye();
        }
        else
        {
            EnableEye();
        }

        player.EyeEnabled += EnableEye;
        player.EyePlaced += EyeInUse;
        player.EyeRecalled += RecallEye;

        // Leg Section

        if (!player.HasLeg)
        {
            DisableLeg();
        }
        else
        {
            EnableLeg();
        }

        player.EyeEnabled += EnableEye;
        player.EyePlaced += EyeInUse;
        player.EyeRecalled += RecallEye;
    }

    void EnableEye()
    {
        Debug.Log("Enabling Eye");
        eyeUI.SetActive(true);
        eyeInUseUI.SetActive(false);
        eyeUnusableUI.SetActive(false);
    }
    void RecallEye()
    {
        Debug.Log("Recalling Eye");
        eyeUI.SetActive(true);
        eyeInUseUI.SetActive(false);
        eyeUnusableUI.SetActive(false);

    }
    void EyeInUse()
    {
        Debug.Log("Eye in use");
        eyeUI.SetActive(true);
        eyeInUseUI.SetActive(true);
        eyeUnusableUI.SetActive(false);


    }
    void DisableEye()
    {
        Debug.Log("Disabling Eye");
        eyeUI.SetActive(false);
        eyeInUseUI.SetActive(false);
        eyeUnusableUI.SetActive(true);
    }


    // ARM Section
    void EnableArm()
    {
        armUI.SetActive(true);
        armInUseUI.SetActive(false);
        armUnusableUI.SetActive(false);
    }
    void RecallArm()
    {
        armUI.SetActive(true);
        armInUseUI.SetActive(false);
        armUnusableUI.SetActive(false);

    }
    void ArmInUse()
    {
        armUI.SetActive(true);
        armInUseUI.SetActive(true);
        armUnusableUI.SetActive(false);


    }
    void DisableArm()
    {
        armUI.SetActive(false);
        armInUseUI.SetActive(false);
        armUnusableUI.SetActive(true);
    }
    // Leg Section
    void EnableLeg()
    {
        legUI.SetActive(true);
        legInUseUI.SetActive(false);
        legUnusableUI.SetActive(false);
    }
    void RecallLeg()
    {
        legUI.SetActive(true);
        legInUseUI.SetActive(false);
        legUnusableUI.SetActive(false);

    }
    void LegInUse()
    {
        legUI.SetActive(true);
        legInUseUI.SetActive(true);
        legUnusableUI.SetActive(false);


    }
    void DisableLeg()
    {
        legUI.SetActive(false);
        legInUseUI.SetActive(false);
        legUnusableUI.SetActive(true);
    }
}
