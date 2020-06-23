﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemiesManager : MonoBehaviour
{
    protected GameManager gameManager;
    protected GameUIController gameUIController;
    //public static EnemiesManager01 Instance;
    protected float waveTimer = 5f;               //每波间隔时间

    protected int totalWaveNum;
    protected int waveNum = 0;                    //敌人波数
    //private int totalGeneratedEnemies = 50;     //总共敌人的数量
    protected int curDisplayedEnemies = 0;        //目前场景中的敌人数量
    protected int curWaveStillHaveEnemies = 0;        //当前波敌人剩余总数

    protected GameObject brave;

    void Awake()
    {
        //Instance = this;
        if (GameManager.INSTANCE == null)
        {
            return;
        }
        gameManager = GameManager.INSTANCE;
        gameManager.setEnemiesManager(this);
        setTotalWaveNum();
    }
    void Start()
    {
        //brave.GetComponent<BufferManager>().getBuffer();
        brave = gameManager.getBrave().gameObject;
        gameUIController = gameManager.getUIController();
        gameUIController.SetCurrentEnemyWavesText(waveNum, totalWaveNum);
        gameUIController.SetCurrentEnemyNumText(curDisplayedEnemies);
    }
    void Update()
    {
        if (waveNum == totalWaveNum && curWaveStillHaveEnemies == 0)
        {
            gameManager.GameOver(true);
            return;
        }
        if (waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
            if (waveTimer <= 0)
            {
                generatorEnemiesWave();
                gameUIController.SetCurrentEnemyWavesText(waveNum, totalWaveNum);
            }
        }
        else
        {
            if (curWaveStillHaveEnemies == 0)
            {
                getBuffer();
                waveTimer = 5f;
            }
        }
    }
    public void EnemiesDestory()
    {
        curDisplayedEnemies--;
        curWaveStillHaveEnemies--;
        gameUIController.SetCurrentEnemyNumText(curDisplayedEnemies);
    }
    protected void generatorEnemiesWave()
    {
        switch (waveNum)
        {
            case 0:
                wave1();
                break;
            case 1:
                wave2();
                break;
            case 2:
                wave3();
                break;
            case 3:
                wave4();
                break;
            case 4:
                wave5();
                break;
            case 5:
                wave6();
                break;
            case 6:
                wave7();
                break;
            case 7:
                wave8();
                break;
            case 8:
                wave9();
                break;
            case 9:
                wave10();
                break;
            case 10:
                wave11();
                break;
            case 11:
                wave12();
                break;
            case 12:
                wave13();
                break;
            case 13:
                wave14();
                break;
            case 14:
                wave15();
                break;
            default:
                break;
        }
        waveNum++;
    }
    protected IEnumerator generatorEnemy(int enemyIndex, float distance, float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        if (enemyIndex == 0)
        {
            ObjectPool.GetInstant().GetObj("TwoHandsSwordEnemy", new Vector3(brave.transform.position[0] + distance, brave.transform.position[1] + 2, brave.transform.position[2]), new Quaternion());
        }
        if (enemyIndex == 1)
        {
            ObjectPool.GetInstant().GetObj("BowEnemy", new Vector3(brave.transform.position[0] + distance, brave.transform.position[1] + 2, brave.transform.position[2]), new Quaternion());
        }
        if (enemyIndex == 2)
        {
            ObjectPool.GetInstant().GetObj("MagicWandEnemy", new Vector3(brave.transform.position[0] + distance, brave.transform.position[1] + 2, brave.transform.position[2]), new Quaternion());
        }
        curDisplayedEnemies++;
        gameUIController.SetCurrentEnemyNumText(curDisplayedEnemies);
    }
    abstract public void getBuffer();
    abstract protected void setTotalWaveNum();
    abstract protected void wave1();
    abstract protected void wave2();
    abstract protected void wave3();
    abstract protected void wave4();
    abstract protected void wave5();
    abstract protected void wave6();
    abstract protected void wave7();
    abstract protected void wave8();
    abstract protected void wave9();
    abstract protected void wave10();
    abstract protected void wave11();
    abstract protected void wave12();
    abstract protected void wave13();
    abstract protected void wave14();
    abstract protected void wave15();
}
