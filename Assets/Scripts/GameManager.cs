using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player playerPrefs;
    public Platform platformPrefs;
    public float minSpawnX;
    public float maxSpawnX;
    public float minSpawnY;
    public float maxSpawnY;

    public CamController mainCam;
    Player m_player;
    int m_score;
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        base.Start();
        GameGUIManager.Ins.UpdateScoreCounting(m_score);
        GameGUIManager.Ins.ShowGameGUI(false);
    }
    public void PlayGame()
    {
        StartCoroutine(PlatformInit());
        GameGUIManager.Ins.ShowGameGUI(true);
    }
    IEnumerator PlatformInit()
    {
        Platform PlatformClone = null;

        if (platformPrefs)
        {
            PlatformClone = Instantiate(platformPrefs, new Vector2(0, Random.Range(minSpawnY, maxSpawnY)), Quaternion.identity);
            platformPrefs.id = PlatformClone.gameObject.GetInstanceID();
        }

        yield return new WaitForSeconds(0.5f);

        if (playerPrefs)
        {
            m_player = Instantiate(playerPrefs, Vector3.up * 3, Quaternion.identity);
            m_player.lastPlatformId = PlatformClone.id;
        }

        if (platformPrefs)
        {
            float spawnX = m_player.transform.position.x + minSpawnX;
            float spawnY = Random.Range(minSpawnY,maxSpawnY);  
            
            Platform PlatformClone01 = Instantiate(platformPrefs,new Vector2(spawnX, spawnY), Quaternion.identity);
            PlatformClone01.id = PlatformClone01.gameObject.GetInstanceID();
        }
    }

    public void CreatPlatform()
    {
        if (!platformPrefs || !m_player) return;

        float spawnX = Random.Range(m_player.transform.position.x + minSpawnX, m_player.transform.position.x + maxSpawnX);
        float spawnY = Random.Range(minSpawnY, maxSpawnY);

        Platform platformClone = Instantiate(platformPrefs, new Vector2(spawnX, spawnY), Quaternion.identity);
        platformClone.id = platformClone.gameObject.GetInstanceID(); 

    }

    public void CreatePlatformAndLerp(float playerXpos)
    {
        if (mainCam)
        {
            mainCam.LerpTrigger(playerXpos+ minSpawnX);
        }
        CreatPlatform();
    }
    public void AddScore()
    {
        m_score++;

        GameGUIManager.Ins.UpdateScoreCounting(m_score);
    }
}
