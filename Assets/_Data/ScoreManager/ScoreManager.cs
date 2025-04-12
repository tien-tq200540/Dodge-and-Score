using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : TienMonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance => instance;

    [SerializeField] protected int score;
    [SerializeField] protected bool canIncreaseScore = true;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float timeLimit = 1f;
    [SerializeField] protected Text scoreText;
    public bool CanIncreaseScore { get => canIncreaseScore; set => canIncreaseScore = value; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogError("Only 1 ScoreManager allows to exists!");
        else instance = this;
        score = 0;
    }

    private void FixedUpdate()
    {
        this.IncreaseScore();
    }

    protected virtual void IncreaseScore()
    {
        if (!canIncreaseScore) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeLimit) return;
        this.timer = 0;
        this.score++;
        this.scoreText.text = $"Score: {this.score}";
    }
}