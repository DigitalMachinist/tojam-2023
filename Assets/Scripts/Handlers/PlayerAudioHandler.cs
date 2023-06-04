using Interactables;
using UnityEngine;

namespace Handlers
{
    public class PlayerAudioHandler : MonoBehaviour
    {
        [SerializeField] Player player;
        
        [Header("Player Sounds")]
        [SerializeField] AudioSource armEnabled;
        [SerializeField] AudioSource armPlaced;
        [SerializeField] AudioSource armRecalled;
        [SerializeField] AudioSource died;
        [SerializeField] AudioSource eyeEnabled;
        [SerializeField] AudioSource eyePlaced;
        [SerializeField] AudioSource eyeRecalled;
        [SerializeField] AudioSource grabEnded;
        [SerializeField] AudioSource grabStarted;
        [SerializeField] AudioSource interactEnded;
        [SerializeField] AudioSource interactStarted;
        [SerializeField] AudioSource jumped;
        [SerializeField] AudioSource kicked;
        [SerializeField] AudioSource landed;
        [SerializeField] AudioSource laserEnded;
        [SerializeField] AudioSource laserStarted;
        [SerializeField] AudioSource legEnabled;
        [SerializeField] AudioSource legPlaced;
        [SerializeField] AudioSource legRecalled;
        [SerializeField] AudioSource moved;
        [SerializeField] AudioSource pauseToggled;
        [SerializeField] AudioSource rotated;
        [SerializeField] AudioSource spawned;
        
        [Header("Interactable Element Sounds")]
        [SerializeField] AudioSource doorLightActivated;
        [SerializeField] AudioSource doorOpened;
        [SerializeField] AudioSource doorClosed;
        [SerializeField] AudioSource armInteractableActivated;
        [SerializeField] AudioSource armInteractableDeactivated;
        [SerializeField] AudioSource eyeInteractableActivated;
        [SerializeField] AudioSource eyeInteractableDeactivated;
        [SerializeField] AudioSource puttHoleActivated;
        [SerializeField] AudioSource puttHoleDeactivated;
        [SerializeField] AudioSource supercollidingSuperbuttonActivated;
        [SerializeField] AudioSource supercollidingSuperbuttonDeactivated;

        private Door[] doors;
        private ArmInteractable[] armInteractables;
        private EyeInteractable[] eyeInteractables;
        private PuttHoleSwitch[] puttHoleSwitches;
        private SupercollidingSuperbutton[] supercollidingSuperbuttons;

        void Start()
        {
            player.ArmEnabled += OnArmEnabled;
            player.ArmPlaced += OnArmPlaced;
            player.ArmRecalled += OnArmRecalled;
            player.Died += OnDied;
            player.EyeEnabled += OnEyeEnabled;
            player.EyePlaced += OnEyePlaced;
            player.EyeRecalled += OnEyeRecalled;
            player.GrabEnded += OnGrabEnded;
            player.GrabStarted += OnGrabStarted;
            player.InteractEnded += OnInteractEnded;
            player.InteractStarted += OnInteractStarted;
            player.Jumped += OnJumped;
            player.Kicked += OnKicked;
            player.Landed += OnLanded;
            player.LaserEnded += OnLaserEnded;
            player.LaserStarted += OnLaserStarted;
            player.LegEnabled += OnLegEnabled;
            player.LegPlaced += OnLegPlaced;
            player.LegRecalled += OnLegRecalled;
            player.Moved += OnMoved;
            player.PauseToggled += OnPauseToggled;
            player.Rotated += OnRotated;
            player.Spawned += OnSpawned;

            doors = FindObjectsOfType<Door>();
            foreach (var door in doors)
            {
                door.LightActivated += OnDoorLightActivated;
                door.Activated += OnDoorOpened;
                door.Deactivated += OnDoorClosed;
            }

            armInteractables = FindObjectsOfType<ArmInteractable>();
            foreach (var armInteractable in armInteractables)
            {
                armInteractable.Switch.Activated += OnArmInteractableActivated;
                armInteractable.Switch.Deactivated += OnArmInteractableDeactivated;
            }

            eyeInteractables = FindObjectsOfType<EyeInteractable>();
            foreach (var eyeInteractable in eyeInteractables)
            {
                eyeInteractable.Switch.Activated += OnEyeInteractableActivated;
                eyeInteractable.Switch.Deactivated += OnEyeInteractableDeactivated;
            }

            puttHoleSwitches = FindObjectsOfType<PuttHoleSwitch>();
            foreach (var puttHoleSwitch in puttHoleSwitches)
            {
                puttHoleSwitch.Activated += OnPuttHoleActivated;
                puttHoleSwitch.Deactivated += OnPuttHoleDeactivated;
            }

            supercollidingSuperbuttons = FindObjectsOfType<SupercollidingSuperbutton>();
            foreach (var supercollidingSuperbutton in supercollidingSuperbuttons)
            {
                supercollidingSuperbutton.Activated += OnSuperCollidingSuperbuttonActivated;
                supercollidingSuperbutton.Deactivated += OnSuperCollidingSuperbuttonDeactivated;
            }
        }

        void OnDestroy()
        {
            player.ArmEnabled -= OnArmEnabled;
            player.ArmPlaced -= OnArmPlaced;
            player.ArmRecalled -= OnArmRecalled;
            player.Died -= OnDied;
            player.EyeEnabled -= OnEyeEnabled;
            player.EyePlaced -= OnEyePlaced;
            player.EyeRecalled -= OnEyeRecalled;
            player.GrabEnded -= OnGrabEnded;
            player.GrabStarted -= OnGrabStarted;
            player.InteractEnded -= OnInteractEnded;
            player.InteractStarted -= OnInteractStarted;
            player.Jumped -= OnJumped;
            player.Kicked -= OnKicked;
            player.Landed -= OnLanded;
            player.LaserEnded -= OnLaserEnded;
            player.LaserStarted -= OnLaserStarted;
            player.LegEnabled -= OnLegEnabled;
            player.LegPlaced -= OnLegPlaced;
            player.LegRecalled -= OnLegRecalled;
            player.Moved -= OnMoved;
            player.PauseToggled -= OnPauseToggled;
            player.Rotated -= OnRotated;
            player.Spawned -= OnSpawned;
            
            foreach (Door door in doors)
            {
                door.LightActivated -= OnDoorLightActivated;
                door.Activated -= OnDoorOpened;
                door.Deactivated -= OnDoorClosed;
            }

            armInteractables = FindObjectsOfType<ArmInteractable>();
            foreach (var armInteractable in armInteractables)
            {
                armInteractable.Switch.Activated -= OnArmInteractableActivated;
                armInteractable.Switch.Deactivated -= OnArmInteractableDeactivated;
            }

            eyeInteractables = FindObjectsOfType<EyeInteractable>();
            foreach (var eyeInteractable in eyeInteractables)
            {
                eyeInteractable.Switch.Activated -= OnEyeInteractableActivated;
                eyeInteractable.Switch.Deactivated -= OnEyeInteractableDeactivated;
            }

            puttHoleSwitches = FindObjectsOfType<PuttHoleSwitch>();
            foreach (var puttHoleSwitch in puttHoleSwitches)
            {
                puttHoleSwitch.Activated -= OnPuttHoleActivated;
                puttHoleSwitch.Deactivated -= OnPuttHoleDeactivated;
            }

            supercollidingSuperbuttons = FindObjectsOfType<SupercollidingSuperbutton>();
            foreach (var supercollidingSuperbutton in supercollidingSuperbuttons)
            {
                supercollidingSuperbutton.Activated -= OnSuperCollidingSuperbuttonActivated;
                supercollidingSuperbutton.Deactivated -= OnSuperCollidingSuperbuttonDeactivated;
            }
        }

        void OnArmEnabled()
        {
            armEnabled.Play();
        }
        
        void OnArmPlaced()
        {
            armPlaced.Play();
        }
        
        void OnArmRecalled()
        {
            armRecalled.Play();
        }
        
        void OnDied()
        {
            died.Play();
        }
        
        void OnEyeEnabled()
        {
            eyeEnabled.Play();
        }
        
        void OnEyePlaced()
        {
            eyePlaced.Play();
        }   
        
        void OnEyeRecalled()
        {
            eyeRecalled.Play();
        }
        
        void OnGrabEnded()
        {
            grabEnded.Play();
        }
        
        void OnGrabStarted()
        {
            grabStarted.Play();
        }
        
        void OnInteractEnded()
        {
            interactEnded.Play();
        }
        
        void OnInteractStarted()
        {
            interactStarted.Play();
        }
        
        void OnJumped()
        {
            jumped.Play();
        }
        
        void OnKicked()
        {
            kicked.Play();
        }
        
        void OnLanded()
        {
            landed.Play();
        }
        
        void OnLaserEnded()
        {
            laserEnded.Play();
        }
        
        void OnLaserStarted()
        {
            laserStarted.Play();
        }
        
        void OnLegEnabled()
        {
            legEnabled.Play();
        }
        
        void OnLegPlaced()
        {
            legPlaced.Play();
        }
        
        void OnLegRecalled()
        {
            legRecalled.Play();
        }
        
        void OnMoved(Vector3 obj)
        {
            rotated.Play();
        }
        
        void OnPauseToggled(bool isPaused)
        {
            pauseToggled.Play();
        }
        
        void OnRotated(Vector3 obj)
        {
            moved.Play();
        }

        void OnSpawned()
        {
            spawned.Play();
        }

        void OnDoorLightActivated()
        {
            if (doorLightActivated == null)
            {
                return;
            }
            
            doorLightActivated.Play();
        }

        void OnDoorOpened()
        {
            if (doorOpened == null)
            {
                return;
            }
            
            doorOpened.Play();
        }

        void OnDoorClosed()
        {
            if (doorClosed == null)
            {
                return;
            }
            
            doorClosed.Play();
        }

        void OnArmInteractableActivated()
        {
            if (armInteractableActivated == null)
            {
                return;
            }
            
            armInteractableActivated.Play();
        }

        void OnArmInteractableDeactivated()
        {
            if (armInteractableDeactivated == null)
            {
                return;
            }
            
            armInteractableDeactivated.Play();
        }

        void OnEyeInteractableActivated()
        {
            if (eyeInteractableActivated == null)
            {
                return;
            }
            
            eyeInteractableActivated.Play();
        }

        void OnEyeInteractableDeactivated()
        {
            if (eyeInteractableDeactivated == null)
            {
                return;
            }
            
            eyeInteractableDeactivated.Play();
        }

        void OnPuttHoleActivated()
        {
            if (puttHoleActivated == null)
            {
                return;
            }
            
            puttHoleActivated.Play();
        }

        void OnPuttHoleDeactivated()
        {
            if (puttHoleDeactivated == null)
            {
                return;
            }
            
            puttHoleDeactivated.Play();
        }

        void OnSuperCollidingSuperbuttonActivated()
        {
            if (supercollidingSuperbuttonActivated == null)
            {
                return;
            }
            
            supercollidingSuperbuttonActivated.Play();
        }

        private void OnSuperCollidingSuperbuttonDeactivated()
        {
            if (supercollidingSuperbuttonDeactivated == null)
            {
                return;
            }
            
            supercollidingSuperbuttonDeactivated.Play();
        }
    }
}