using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [SerializeField] public string RoomerName;
    [SerializeField] public int RoomNumber;
    [SerializeField] public bool HasPet;
    [SerializeField] private TextMeshProUGUI roomNameText;
    [SerializeField] private TextMeshProUGUI roomNumberText;
    [SerializeField] private Toggle hasRetToggle;

    private void Start()
    {
        UI();
    }

    public void Initialize(string roomername, int roomNumber, bool hasPet)
    {
        RoomerName = roomername;
        RoomNumber = roomNumber;
        HasPet = hasPet;
        UI();
    }

    public Room Clone()
    {
        Room newRoom = Instantiate(this);
        newRoom.RoomerName = this.RoomerName;
        newRoom.RoomNumber = this.RoomNumber;
        newRoom.HasPet = this.HasPet;
        return newRoom;
    }

    public void UI()
    {
        roomNameText.text = $"Name: {RoomerName}";
        roomNumberText.text = $"Room Num: {RoomNumber}";
        hasRetToggle.isOn = HasPet;
    }
}
