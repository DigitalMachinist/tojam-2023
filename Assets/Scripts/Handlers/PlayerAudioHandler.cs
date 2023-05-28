using UnityEngine;

namespace Handlers
{
    public class PlayerAudioHandler : MonoBehaviour
    {
        [SerializeField] Player player;
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
        [SerializeField] AudioSource laserEnded;
        [SerializeField] AudioSource laserStarted;
        [SerializeField] AudioSource legEnabled;
        [SerializeField] AudioSource legPlaced;
        [SerializeField] AudioSource legRecalled;
        [SerializeField] AudioSource moved;
        [SerializeField] AudioSource rotated;
        [SerializeField] AudioSource spawned;

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
            player.LaserEnded += OnLaserEnded;
            player.LaserStarted += OnLaserStarted;
            player.LegEnabled += OnLegEnabled;
            player.LegPlaced += OnLegPlaced;
            player.LegRecalled += OnLegRecalled;
            player.Moved += OnMoved;
            player.Rotated += OnRotated;
            player.Spawned += OnSpawned;
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
            player.LaserEnded -= OnLaserEnded;
            player.LaserStarted -= OnLaserStarted;
            player.LegEnabled -= OnLegEnabled;
            player.LegPlaced -= OnLegPlaced;
            player.LegRecalled -= OnLegRecalled;
            player.Moved -= OnMoved;
            player.Rotated -= OnRotated;
            player.Spawned -= OnSpawned;
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
        
        void OnRotated(Vector3 obj)
        {
            moved.Play();
        }

        void OnMoved(Vector3 obj)
        {
            rotated.Play();
        }
        
        void OnSpawned()
        {
            spawned.Play();
        }
    }
}