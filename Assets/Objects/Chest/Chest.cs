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

        [VarwinInspector(English: "Close chest on start")]
        public bool CloseOnStart { get; set; }

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void Start()
        {
            IsOpened = !CloseOnStart;
        }

        [Checker(English: "Chest is opened", Russian: "Сундук открыт")]
        public bool ChestIsOpened() => IsOpened;

        [ActionGroup("Top")]
        [Action(English: "Open the chest", Russian: "Открыть сундук")]
        public void OpenTheChest() => IsOpened = true;
        [ActionGroup("Top")]
        [Action(English: "Close the chest", Russian: "Закрыть сундук")]
        public void CloseTheChest() => IsOpened = false;
    }
}
