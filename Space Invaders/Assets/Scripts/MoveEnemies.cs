using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MoveEnemies : MonoBehaviour
{
    public static MoveEnemies Instance;
    [SerializeField]
    int nrOfEnemies;

    [SerializeField]
    GameObject enemyShip;

    [SerializeField]
    GameObject board;

    public GameObject bullet_obj;

    private static List<GameObject> enemies;
    private static int killedEnemies=0;
    public float freq;
    private float lastMovement;
    private int mov;
    private float shotF=1.5f, lastShot;
    private int lives;

    public TextMeshProUGUI points, hp;

    private void Awake()
    {
        Instance = this;
    }

    public void HurtPlayer()
    {
        lives -= 1;
        hp.text = "HP: " + lives;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void killEnemy()
    {
        killedEnemies += 1;

        points.text = "Points: " + killedEnemies;
        if (killedEnemies % enemies.Count == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("F3_Corvette");
    }


    void Start()
    {
        lives = 3;
        hp.text = "HP: " + lives;
        points.text = "Points: " + killedEnemies;
        lastMovement = Time.time;
        mov = 25;
        enemies = new List<GameObject>();
        for(int i=0;i<nrOfEnemies; i++)
        {
            if(i % 2 == 0)
            {
                GameObject enemy = Instantiate(enemyShip,
                    board.transform.position + new Vector3(100 * (i + 1) * Mathf.Pow(-1, i), 0, 0),
                    board.transform.rotation);
                enemies.Add(enemy);
            }
            else
            {
                GameObject enemy = Instantiate(enemyShip, board.transform.position + new Vector3(100 * i * Mathf.Pow(-1, i), 0, 0), board.transform.rotation);
                enemies.Add(enemy);
            }
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].transform.SetPositionAndRotation(new Vector3(enemies[i].transform.position.x, 25, enemies[i].transform.position.z), enemies[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastMovement >= (1 / freq))
        {
            if (enemies[enemies.Count - 2].transform.position.x <= -650)
            {
                mov = 25;
            }
            else if (enemies[enemies.Count - 1].transform.position.x >= 650)
            {
                mov = -25;
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].transform.SetPositionAndRotation(new Vector3(enemies[i].transform.position.x + mov, enemies[i].transform.position.y , enemies[i].transform.position.z), enemies[i].transform.rotation);
            }
            lastMovement = Time.time;
        }

        if(Time.time - lastShot >= (1 / shotF))
        {
            for(int i=0; i < enemies.Count; i++)
            {
                if (enemies[i].activeSelf)
                {
                    int r = Random.Range(0, 5);
                    if(r == 0)
                    {
                        Vector3 pos = new Vector3(enemies[i].transform.position.x, 
                            enemies[i].transform.position.y, 
                            enemies[i].transform.position.z - 200);
                        GameObject bullet = Instantiate(bullet_obj, pos, bullet_obj.transform.rotation);
                        bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -500);
                        lastShot = Time.time;
                    }
                }
            }
        }
    }
}
