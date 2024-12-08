using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour
{

    [SerializeField] private List<GameObject> cubs = new List<GameObject>();

    private void Start()
    {
        SortCubs();
    }

    private void SortCubs()
    {
        for (int i = 0; i < cubs.Count; i++)
        {
            for(int j = 0; j < cubs.Count -1; j++)
            {
                if (cubs[i].transform.localScale.x < cubs[j].transform.localScale.x)
                {
                    GameObject x = cubs[i];
                    cubs[i] = cubs[j];
                    cubs[j] = x;
                }
            }
        }

        for (int i = 0;i < cubs.Count; i++)
        {
            cubs[i].transform.position = new Vector3(i * 3, 0, 0);
        }
    }
}
