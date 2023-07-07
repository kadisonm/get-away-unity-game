using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Menu,
        Playing,
    }

    public static GameManager Instance { get; private set; }

    public GameObject Player;
    [HideInInspector] public Player PlayerValues;

    public float ElapsedRoundTime { get; private set; }
    public GameState CurrentState { get; private set; }

    public int CollectedRoundMoney;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        PlayerValues = Player.GetComponent<Player>();
    }

    private void Start()
    {
        BeginRound();
    }

    private void Update()
    {
        if (CurrentState == GameState.Playing)
        {
            UpdateRound();
        }
    }

    private void BeginRound()
    {
        CurrentState = GameState.Playing;
        MapManager.Instance.InitialiseBuildings();
        ElapsedRoundTime = 0;
        CollectedRoundMoney = 0;
    }

    private void UpdateRound()
    {
        ElapsedRoundTime += Time.deltaTime;
    }

    public void EndRound()
    {
        Time.timeScale = 0.2f;

        UIManager.Instance.OpenDeathScreen();
    }
}
