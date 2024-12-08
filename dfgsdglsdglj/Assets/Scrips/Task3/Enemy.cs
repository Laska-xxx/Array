using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public string Name;
    [SerializeField] public int Lvl;
    [SerializeField] public float Health;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        UI();
    }

    public void Initialize(string name, int lvl, float health)
    {
        Name = name;
        Lvl = lvl;
        Health = health;
        UI();
    }

    public void Boss()
    {
        Name = "Boss";
        Lvl += 1;
        Health *= 3;
        UI();
    }

    private void UI()
    {
        nameText.text = $"Name: {Name}";
        lvlText.text = $"Level: {Lvl}";
        healthText.text = $"Health: {Health}";
    }
}
