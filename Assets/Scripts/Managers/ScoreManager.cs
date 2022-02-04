using System;
using Architecture.Variables;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Setup")] 
    [SerializeField] private FloatVariable goldScoreTime;
    [SerializeField] private FloatVariable silverScoreTime;
    [SerializeField] private FloatVariable bronzeScoreTime;

    [Header("Variables")] [SerializeField] private FloatVariable levelTime;

    public static event Action BronzeTimePassed;
    public static event Action SilverTimePassed;
    public static event Action GoldTimePassed;

    private void Awake()
    {
        ResetTime();
    }

    private void Update()
    {
        levelTime.Value += Time.deltaTime;

        //TODO: Make This better to not keep invoking
        if (levelTime.Value > bronzeScoreTime.Value)
            BronzeTimePassed?.Invoke();

        if (levelTime.Value > silverScoreTime.Value)
            SilverTimePassed?.Invoke();

        if (levelTime.Value > goldScoreTime.Value)
            GoldTimePassed?.Invoke();
    }

    private void ResetTime()
    {
        levelTime.Value = 0;
    }
}