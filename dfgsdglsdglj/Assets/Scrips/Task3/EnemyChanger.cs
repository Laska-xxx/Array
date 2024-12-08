using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyChanger : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemy = new List<Enemy>();
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button healthButton;
    [SerializeField] private Button levelButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button bossButton;

    private void Start()
    {
        healthButton.onClick.AddListener(Health);
        levelButton.onClick.AddListener(Level);
        resetButton.onClick.AddListener(ResetGame);
        bossButton.onClick.AddListener(ToBoss);
    }

    private void Health()
    {
        float input;
        if (float.TryParse(inputField.text, out input))
        {
            foreach (Enemy enemy in enemy)
            {
                if(enemy.Health > input)
                {
                    enemy.gameObject.SetActive(true);
                }
                else
                {
                    enemy.gameObject.SetActive(false);
                }
            }
        }
    }

    private void Level()
    {
        int input;
        if (int.TryParse(inputField.text,out input))
        {
            foreach(Enemy enemy in enemy)
            {
                if(enemy.Lvl == input)
                {
                    enemy.gameObject.SetActive(true);
                }
                else
                {
                    enemy.gameObject.SetActive(false);
                }
            }
        }
    }

    private void ResetGame()
    {
        foreach(Enemy enemy in enemy)
        {
            enemy.gameObject.SetActive(true);
        }
    }

    private void ToBoss()
    {
        string input = inputField.text;
        foreach(Enemy enemy in enemy)
        {
            if(enemy.Name == input)
            {
                enemy.Boss();
            }
        }
    }


}
