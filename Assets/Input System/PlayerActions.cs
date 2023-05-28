//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input System/PlayerActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""8ed2f13a-0226-4945-9d8c-4c5ccdc0a12b"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""2e985255-9129-44db-bab8-3d048113f969"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3ea1eb25-d964-4aae-9424-891ad832f5a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookAround"",
                    ""type"": ""Value"",
                    ""id"": ""80b412ae-51a0-4226-86d0-b78021affd7c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AttachDetachEye"",
                    ""type"": ""Button"",
                    ""id"": ""2148d957-f280-4af6-9700-8dd63c77552b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseEye"",
                    ""type"": ""Button"",
                    ""id"": ""8e01304e-0d55-4cc4-a55d-3e0faf3ebcc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttachDetachLeftArm"",
                    ""type"": ""Button"",
                    ""id"": ""4f1fde25-514c-42f8-9b03-9246eb668697"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseLeftArm"",
                    ""type"": ""Button"",
                    ""id"": ""ec3774a5-081f-46c3-96de-ad01748f0493"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttachDetachRightArm"",
                    ""type"": ""Button"",
                    ""id"": ""454d4df6-8e5e-49b0-8cba-22ca687fe330"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseRightArm"",
                    ""type"": ""Button"",
                    ""id"": ""97dc0da5-4ac9-4ac7-b764-d94069206d17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttachDetachLeftLeg"",
                    ""type"": ""Button"",
                    ""id"": ""28d38706-632d-447d-bcb4-64be1d147236"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseLeftLeg"",
                    ""type"": ""Button"",
                    ""id"": ""2b6a25dc-8d6b-4de7-a1e5-a4aa80bcc175"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttachDetachRightLeg"",
                    ""type"": ""Button"",
                    ""id"": ""60ebeb57-b0c5-446b-bd35-40fcc557fe45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseRightLeg"",
                    ""type"": ""Button"",
                    ""id"": ""34ad1da1-d685-4469-a668-7da0bb1388b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector (Keyboard)"",
                    ""id"": ""b6bb27a9-2f94-45cf-a1a9-7db53647c486"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4044c657-b35b-4a36-b335-d5e836cf8fff"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d21ac92f-1493-435c-b9bd-5a5b2b3c4334"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""58fb9f7c-2743-4e95-8ff1-5da88a0ff93d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7d16fb18-9947-4829-9d68-f3386be3df03"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector (Gamepad)"",
                    ""id"": ""ab32695c-9368-4eac-bddd-77fff636c577"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3da092cb-ac3c-41ce-907b-21e0d2cee4aa"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eeb024fb-2e8e-4ded-a538-ab1bfbb9e920"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3e857070-51e2-4709-905d-eea400a3ebaf"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8131d4e7-1d71-4517-a149-216090631407"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e1c6489-88db-4635-bb7d-c1c4fcd3058f"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachEye"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b35ab74c-49d9-4a13-a5e5-e365ef06f326"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachEye"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bff647b-2812-4f61-a2cd-4a598b339a76"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseEye"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd7e5064-302c-4e14-a927-88bc108165ef"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseEye"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f6d9e20-7296-4803-a4f9-3b5485011140"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachLeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bc1ee68-49f2-4fcf-bf6a-cf6d784672ce"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachLeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a4d50e3-a468-4681-b3a6-210e5fc06685"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseLeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf1d1dd1-6208-4853-8457-feb70b878d9a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseLeftArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67cc9f6d-66e4-4b6e-a703-4ee9ef6fc39c"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachRightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""352529b6-8b9b-4f48-8196-fd7388e12120"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachRightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f72faf1-b400-4aa3-84bf-05ec30c5e147"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a98f654-4944-4b3f-b195-d46c623bf771"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRightArm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4c11382-a9ff-491b-b306-b79f0c9403c9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachLeftLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a282d985-ffc7-46ac-83e0-d20cecdb3214"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachLeftLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db121334-536e-4094-90ce-7f7f40fccdc7"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseLeftLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7ddaa39-b665-4a4a-8854-eb26e765db6e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseLeftLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""137158b8-0926-4794-ba42-d556975119b9"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachRightLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ade65e54-e5ef-4dde-bf42-797087995e46"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttachDetachRightLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45c89dee-7353-451c-a537-1381f29d510b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRightLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a02799f0-b1a9-4a8e-b347-732dd132b0a9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseRightLeg"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c50e50a-845b-496c-9d23-ef03f37ba0cf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4272641a-03a5-4f96-9b95-8b44f7a3effe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a75c28ef-c54d-42e9-bb40-be45ccdbf9b5"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""32a01bf4-8ccc-459c-90a1-1de0ba65474a"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a2225ee3-3c48-4f3a-93e3-3b7c07ca1821"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a754f356-f402-4a7e-aeb3-ffe020c33c63"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""62211031-9228-4a67-a7dc-058e759e518f"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""42739554-ec69-4b2b-99eb-5de7320b7abd"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e9e9a8ce-08fb-4cce-9a14-a3c3fabaf0ca"",
                    ""path"": ""<Mouse>/delta/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""792273f2-5c31-43b7-999b-3883af900f71"",
                    ""path"": ""<Mouse>/delta/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c25d91ce-7f05-41cc-8b20-6625a08d3100"",
                    ""path"": ""<Mouse>/delta/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""02da6e7c-d5e1-4cc0-b9f3-f0a65d816e53"",
                    ""path"": ""<Mouse>/delta/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookAround"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Walk = m_PlayerActionMap.FindAction("Walk", throwIfNotFound: true);
        m_PlayerActionMap_Jump = m_PlayerActionMap.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActionMap_LookAround = m_PlayerActionMap.FindAction("LookAround", throwIfNotFound: true);
        m_PlayerActionMap_AttachDetachEye = m_PlayerActionMap.FindAction("AttachDetachEye", throwIfNotFound: true);
        m_PlayerActionMap_UseEye = m_PlayerActionMap.FindAction("UseEye", throwIfNotFound: true);
        m_PlayerActionMap_AttachDetachLeftArm = m_PlayerActionMap.FindAction("AttachDetachLeftArm", throwIfNotFound: true);
        m_PlayerActionMap_UseLeftArm = m_PlayerActionMap.FindAction("UseLeftArm", throwIfNotFound: true);
        m_PlayerActionMap_AttachDetachRightArm = m_PlayerActionMap.FindAction("AttachDetachRightArm", throwIfNotFound: true);
        m_PlayerActionMap_UseRightArm = m_PlayerActionMap.FindAction("UseRightArm", throwIfNotFound: true);
        m_PlayerActionMap_AttachDetachLeftLeg = m_PlayerActionMap.FindAction("AttachDetachLeftLeg", throwIfNotFound: true);
        m_PlayerActionMap_UseLeftLeg = m_PlayerActionMap.FindAction("UseLeftLeg", throwIfNotFound: true);
        m_PlayerActionMap_AttachDetachRightLeg = m_PlayerActionMap.FindAction("AttachDetachRightLeg", throwIfNotFound: true);
        m_PlayerActionMap_UseRightLeg = m_PlayerActionMap.FindAction("UseRightLeg", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private List<IPlayerActionMapActions> m_PlayerActionMapActionsCallbackInterfaces = new List<IPlayerActionMapActions>();
    private readonly InputAction m_PlayerActionMap_Walk;
    private readonly InputAction m_PlayerActionMap_Jump;
    private readonly InputAction m_PlayerActionMap_LookAround;
    private readonly InputAction m_PlayerActionMap_AttachDetachEye;
    private readonly InputAction m_PlayerActionMap_UseEye;
    private readonly InputAction m_PlayerActionMap_AttachDetachLeftArm;
    private readonly InputAction m_PlayerActionMap_UseLeftArm;
    private readonly InputAction m_PlayerActionMap_AttachDetachRightArm;
    private readonly InputAction m_PlayerActionMap_UseRightArm;
    private readonly InputAction m_PlayerActionMap_AttachDetachLeftLeg;
    private readonly InputAction m_PlayerActionMap_UseLeftLeg;
    private readonly InputAction m_PlayerActionMap_AttachDetachRightLeg;
    private readonly InputAction m_PlayerActionMap_UseRightLeg;
    public struct PlayerActionMapActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerActionMapActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_PlayerActionMap_Walk;
        public InputAction @Jump => m_Wrapper.m_PlayerActionMap_Jump;
        public InputAction @LookAround => m_Wrapper.m_PlayerActionMap_LookAround;
        public InputAction @AttachDetachEye => m_Wrapper.m_PlayerActionMap_AttachDetachEye;
        public InputAction @UseEye => m_Wrapper.m_PlayerActionMap_UseEye;
        public InputAction @AttachDetachLeftArm => m_Wrapper.m_PlayerActionMap_AttachDetachLeftArm;
        public InputAction @UseLeftArm => m_Wrapper.m_PlayerActionMap_UseLeftArm;
        public InputAction @AttachDetachRightArm => m_Wrapper.m_PlayerActionMap_AttachDetachRightArm;
        public InputAction @UseRightArm => m_Wrapper.m_PlayerActionMap_UseRightArm;
        public InputAction @AttachDetachLeftLeg => m_Wrapper.m_PlayerActionMap_AttachDetachLeftLeg;
        public InputAction @UseLeftLeg => m_Wrapper.m_PlayerActionMap_UseLeftLeg;
        public InputAction @AttachDetachRightLeg => m_Wrapper.m_PlayerActionMap_AttachDetachRightLeg;
        public InputAction @UseRightLeg => m_Wrapper.m_PlayerActionMap_UseRightLeg;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActionMapActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Add(instance);
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @LookAround.started += instance.OnLookAround;
            @LookAround.performed += instance.OnLookAround;
            @LookAround.canceled += instance.OnLookAround;
            @AttachDetachEye.started += instance.OnAttachDetachEye;
            @AttachDetachEye.performed += instance.OnAttachDetachEye;
            @AttachDetachEye.canceled += instance.OnAttachDetachEye;
            @UseEye.started += instance.OnUseEye;
            @UseEye.performed += instance.OnUseEye;
            @UseEye.canceled += instance.OnUseEye;
            @AttachDetachLeftArm.started += instance.OnAttachDetachLeftArm;
            @AttachDetachLeftArm.performed += instance.OnAttachDetachLeftArm;
            @AttachDetachLeftArm.canceled += instance.OnAttachDetachLeftArm;
            @UseLeftArm.started += instance.OnUseLeftArm;
            @UseLeftArm.performed += instance.OnUseLeftArm;
            @UseLeftArm.canceled += instance.OnUseLeftArm;
            @AttachDetachRightArm.started += instance.OnAttachDetachRightArm;
            @AttachDetachRightArm.performed += instance.OnAttachDetachRightArm;
            @AttachDetachRightArm.canceled += instance.OnAttachDetachRightArm;
            @UseRightArm.started += instance.OnUseRightArm;
            @UseRightArm.performed += instance.OnUseRightArm;
            @UseRightArm.canceled += instance.OnUseRightArm;
            @AttachDetachLeftLeg.started += instance.OnAttachDetachLeftLeg;
            @AttachDetachLeftLeg.performed += instance.OnAttachDetachLeftLeg;
            @AttachDetachLeftLeg.canceled += instance.OnAttachDetachLeftLeg;
            @UseLeftLeg.started += instance.OnUseLeftLeg;
            @UseLeftLeg.performed += instance.OnUseLeftLeg;
            @UseLeftLeg.canceled += instance.OnUseLeftLeg;
            @AttachDetachRightLeg.started += instance.OnAttachDetachRightLeg;
            @AttachDetachRightLeg.performed += instance.OnAttachDetachRightLeg;
            @AttachDetachRightLeg.canceled += instance.OnAttachDetachRightLeg;
            @UseRightLeg.started += instance.OnUseRightLeg;
            @UseRightLeg.performed += instance.OnUseRightLeg;
            @UseRightLeg.canceled += instance.OnUseRightLeg;
        }

        private void UnregisterCallbacks(IPlayerActionMapActions instance)
        {
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @LookAround.started -= instance.OnLookAround;
            @LookAround.performed -= instance.OnLookAround;
            @LookAround.canceled -= instance.OnLookAround;
            @AttachDetachEye.started -= instance.OnAttachDetachEye;
            @AttachDetachEye.performed -= instance.OnAttachDetachEye;
            @AttachDetachEye.canceled -= instance.OnAttachDetachEye;
            @UseEye.started -= instance.OnUseEye;
            @UseEye.performed -= instance.OnUseEye;
            @UseEye.canceled -= instance.OnUseEye;
            @AttachDetachLeftArm.started -= instance.OnAttachDetachLeftArm;
            @AttachDetachLeftArm.performed -= instance.OnAttachDetachLeftArm;
            @AttachDetachLeftArm.canceled -= instance.OnAttachDetachLeftArm;
            @UseLeftArm.started -= instance.OnUseLeftArm;
            @UseLeftArm.performed -= instance.OnUseLeftArm;
            @UseLeftArm.canceled -= instance.OnUseLeftArm;
            @AttachDetachRightArm.started -= instance.OnAttachDetachRightArm;
            @AttachDetachRightArm.performed -= instance.OnAttachDetachRightArm;
            @AttachDetachRightArm.canceled -= instance.OnAttachDetachRightArm;
            @UseRightArm.started -= instance.OnUseRightArm;
            @UseRightArm.performed -= instance.OnUseRightArm;
            @UseRightArm.canceled -= instance.OnUseRightArm;
            @AttachDetachLeftLeg.started -= instance.OnAttachDetachLeftLeg;
            @AttachDetachLeftLeg.performed -= instance.OnAttachDetachLeftLeg;
            @AttachDetachLeftLeg.canceled -= instance.OnAttachDetachLeftLeg;
            @UseLeftLeg.started -= instance.OnUseLeftLeg;
            @UseLeftLeg.performed -= instance.OnUseLeftLeg;
            @UseLeftLeg.canceled -= instance.OnUseLeftLeg;
            @AttachDetachRightLeg.started -= instance.OnAttachDetachRightLeg;
            @AttachDetachRightLeg.performed -= instance.OnAttachDetachRightLeg;
            @AttachDetachRightLeg.canceled -= instance.OnAttachDetachRightLeg;
            @UseRightLeg.started -= instance.OnUseRightLeg;
            @UseRightLeg.performed -= instance.OnUseRightLeg;
            @UseRightLeg.canceled -= instance.OnUseRightLeg;
        }

        public void RemoveCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);
    public interface IPlayerActionMapActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLookAround(InputAction.CallbackContext context);
        void OnAttachDetachEye(InputAction.CallbackContext context);
        void OnUseEye(InputAction.CallbackContext context);
        void OnAttachDetachLeftArm(InputAction.CallbackContext context);
        void OnUseLeftArm(InputAction.CallbackContext context);
        void OnAttachDetachRightArm(InputAction.CallbackContext context);
        void OnUseRightArm(InputAction.CallbackContext context);
        void OnAttachDetachLeftLeg(InputAction.CallbackContext context);
        void OnUseLeftLeg(InputAction.CallbackContext context);
        void OnAttachDetachRightLeg(InputAction.CallbackContext context);
        void OnUseRightLeg(InputAction.CallbackContext context);
    }
}
