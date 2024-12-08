using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<Room> rooms = new List<Room>();
    private List<Room> resetRooms = new List<Room>();
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private GameObject roomPrefab;
    [SerializeField] private Button ResetButton;
    [SerializeField] private Button GameButton;

    void Start()
    {
        CloneList(resetRooms, rooms);
        ResetButton.onClick.AddListener(ResetRoom);
        GameButton.onClick.AddListener(Game);
    }

    private void ResetRoom()
    {
        UpdateUI(resetRooms);
        CloneList(rooms, resetRooms);
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                      

    private void Game()
    {
        HavePet();
        NameSmith();
        OneNumNumbers();
        UpendRoomer();
        DelRoom();
        UpendRoomerWithPet();
        UpdateUI(rooms);
    }

    private void HavePet()
    {
        int countPet = 0;
        foreach (var room in rooms)
        {
            if (room.HasPet) countPet++;
        }
        Debug.Log($"Количество жильцов с животными: {countPet}");
    }

    private void NameSmith()
    {
        int countRoomer = 0;
        foreach(var room in rooms)
        {
            if(room.RoomerName.ToLower().Contains("smith")) countRoomer++;
        }
        Debug.Log($"Количество жильцов с именем 'Смит': {countRoomer}");
    }

    private void OneNumNumbers()
    {
        int countRoom = 0;
        foreach( var room in rooms)
        {
            if(room.RoomNumber < 10) countRoom++;
        }
        Debug.Log($"Количество комнат с однозначными номерами: {countRoom}");
    }

    private void UpendRoomer()
    {
        rooms.Reverse();
    }

    private void DelRoom()
    {
        for (int i = rooms.Count - 1; i >= 0; i--)
        {
            if (rooms[i].RoomNumber % 3 == 0) 
            {
                Destroy(rooms[i].gameObject);
                rooms.RemoveAt(i);
            }
        }
        Debug.Log("Комнаты удалены");
    }

    private void UpendRoomerWithPet()
    {
        int lastRoomerWithPetNum = 0;
        int minRoomNumberNum = 0;
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].HasPet) lastRoomerWithPetNum = i;
            if (rooms[i].RoomNumber < rooms[minRoomNumberNum].RoomNumber) minRoomNumberNum = i;
        }
        var curRoom = rooms[minRoomNumberNum];
        rooms[minRoomNumberNum] = rooms[lastRoomerWithPetNum];
        rooms[lastRoomerWithPetNum] = curRoom;

        Debug.Log("последнее задание выполнено");
    }

    private void CloneList(List<Room> list1, List<Room> list2)
    {
        list1.Clear(); 

        foreach (var room in list2)
        {
            if (room != null)
            {
                Room clonedRoom = room.Clone(); 
                list1.Add(clonedRoom);
            }
        }
    }

    private void UpdateUI(List<Room> list)
    {
        foreach (Transform child in gridLayoutGroup.transform)
        {
            Destroy(child.gameObject); 
        }

        foreach (var room in list)
        {
            Room newRoomUI = Instantiate(roomPrefab, gridLayoutGroup.transform).GetComponent<Room>();
            newRoomUI.Initialize(room.RoomerName, room.RoomNumber, room.HasPet);
        }
    }
}
