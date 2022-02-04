using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Loading
{
    public class TextBreathingEffect : MonoBehaviour
    {
        private TMP_Text text;

        private void Awake() => text = GetComponent<TMP_Text>();

        private void Start() => text.DOFade(0.3f, 2f).SetLoops(-1, LoopType.Yoyo);
    }
}