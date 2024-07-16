using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float highscore = 0;
    public static GameManager Instance { get; private set; }

    public CharacterManager CharacterManager { get; private set; }

    public UIManager UIManager { get; private set; }

    public LevelManager LevelManager { get; private set; }

    public EnemyManager EnemyManager { get; private set; }

    public ButtonManager ButtonManager { get; private set; }

    public ScenesManager ScenesManager { get; private set;}



    [SerializeField] CharacterManager characterManager;

    [SerializeField] LevelManager levelManager;

    [SerializeField] EnemyManager enemyManager;

    [SerializeField] UIManager uımanager;

    [SerializeField] ButtonManager buttonManager;

    [SerializeField] ScenesManager scenesManager;
    





    





    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CharacterManager = characterManager;
        LevelManager = levelManager;
        EnemyManager = enemyManager;
        UIManager = uımanager;
        ButtonManager = buttonManager;
        ScenesManager = scenesManager;
    }

    private void Update()
    {
       
    }
}
