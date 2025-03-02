using UnityEngine;
using Varwin.Public;

namespace Varwin.Types.Chest_af11eb3363a5470791085694463ffb25
{
    [VarwinComponent(English: "Chest")]
    public class Chest : VarwinObject
    {
        private bool _isOpened = false;
        private bool IsOpened
        {
            get => _isOpened;
            set
            {
                _isOpened = value;
                _animator.SetBool("IsOpen", value);
            }
        }

        [Header("Sounds")]
        public AudioClip OpenSound;
        public AudioClip CloseSound;

        [VarwinInspector(English: "Close chest on start")]
        public bool CloseOnStart { get; set; }

        [Tooltip("Float from 0 to 1.")]
        [VarwinInspector(English: "Sounds volume")]
        public float SoundsVolume { get; set; } = 1f;

        private AudioSource _audioSource;
        private Animator _animator;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
        }
        private void Start()
        {
            IsOpened = !CloseOnStart;
            if (SoundsVolume >= 0 || SoundsVolume <= 1)
                _audioSource.volume = SoundsVolume;
        }

        [Checker(English: "Chest is opened", Russian: "Сундук открыт")]
        public bool ChestIsOpened() => IsOpened;

        [ActionGroup("Top")]
        [Action(English: "Open the chest", Russian: "Открыть сундук")]
        public void OpenTheChest()
        {
            _audioSource.PlayOneShot(OpenSound);
            IsOpened = true;
        }
        [ActionGroup("Top")]
        [Action(English: "Close the chest", Russian: "Закрыть сундук")]
        public void CloseTheChest()
        {
            _audioSource.PlayOneShot(CloseSound);
            IsOpened = false;
        }
    }
}
