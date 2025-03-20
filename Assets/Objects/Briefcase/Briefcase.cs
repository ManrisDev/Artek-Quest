using System.Collections.Generic;
using UnityEngine;
using Varwin.Public;

namespace Varwin.Types.Briefcase_f894de00da834a25a7742da6b0374248
{
    [VarwinComponent(English: "Briefcase")]
    public class Briefcase : VarwinObject
    {
        //[Header("Test")]
        //public int WheelPosition;
        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //        _wheels[WheelPosition].OnUseStart(null);
        //}

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

        [Header("Components")]
        [SerializeField] private Transform _upperPart;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<Wheel> _wheels;
        [Space]
        public AudioClip OpenSound;
        public AudioClip ShelkSound;

        #region Varwin Variables
        [VarwinInspector("Close chest on start")]
        public bool CloseOnStart { get; set; } = true;

        [VarwinInspector("The combination to open")]
        [field:SerializeField] public int OpenCombination { get; set; }

        [VarwinInspector("Sounds volume")]
        public float SoundsVolume { get; set; } = 1f;
        #endregion
        public delegate void BriefcaseEventHandler();
        [LogicEvent(English: "Breefcase is opened")]
        public event BriefcaseEventHandler BreefcaseIsOpened;

        private Animator _animator;

        
        private int[] _currentCombination = new int[3];

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            foreach (var wheel in _wheels)
            {
                wheel.NumberStartChanging += OnNumberStartChanging;
                wheel.NumberWasChanged += OnNumberChange;
            }
        }
        private void Start()
        {
            IsOpened = !CloseOnStart;
            if (SoundsVolume >= 0 || SoundsVolume <= 1)
                _audioSource.volume = SoundsVolume;
        }

        [Action(English: "Set child to upper part")]
        public void SetChild(Wrapper wrapper) => wrapper.GetGameObject().transform.parent = _upperPart;

        private void OnNumberStartChanging() => _audioSource.PlayOneShot(ShelkSound);
        private void OnNumberChange(int position, int number)
        {
            _currentCombination[position] = number;
            if (CombinationIsCorrect())
                OpenTheBriefcase();
        }
        private bool CombinationIsCorrect()
        {
            int currentCombinationAsNubmer = _currentCombination[0] * 100 + _currentCombination[1] * 10 + _currentCombination[2];
            return currentCombinationAsNubmer == OpenCombination;
        }

        public void OpenTheBriefcase()
        {
            if (IsOpened) return;
            _audioSource.PlayOneShot(OpenSound);
            IsOpened = true;
            BreefcaseIsOpened?.Invoke();
        }
    }
}
