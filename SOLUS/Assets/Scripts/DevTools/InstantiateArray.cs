using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateArray : MonoBehaviour
{
    [SerializeField] private GameObject model;
#pragma warning disable CS0108
    [SerializeField] private GameObject light;
#pragma warning restore CS0108
    [SerializeField] private int count_x, count_z;
    [SerializeField] private Transform _start, _end;

    private GameObject[,] models;
    private GameObject[] lights;

    public void instantiate()
    {
        Vector3 start = _start.position;
        Vector3 end = _end.position;

        models = new GameObject[count_x, count_z];
        lights = new GameObject[count_x];

        // Instantiate Models
        for (int i = 0; i < count_x; i++)
        {
            for (int j = 0; j < count_z; j++)
            {
                // position of one piece
                float piece_x = (end.x - start.x) / count_x;
                float piece_z = (end.z - start.z) / count_z;

                //                          pos in array        offset
                float calcPos_x = start.x + (piece_x * i) + (piece_x / 2);
                float calcPos_y = start.y;
                float calcPos_z = start.z + (piece_z * j) + (piece_z / 2);

                Vector3 calcPos = new Vector3(calcPos_x, calcPos_y, calcPos_z);

                models[i, j] = Instantiate(model, calcPos, Quaternion.identity, transform);
            }
        }

        Debug.Log("instantiating lights..");

        // Instantiate Lights
        for (int i = 0; i < count_x; i++)
        {
            float piece_x = (end.x - start.x) / count_x;

            float calcPos_x = start.x + (piece_x * i) + (piece_x / 2);
            float calcPos_y = start.y;
            float calcPos_z = 0f; //(end.z - start.z) / 2;

            Vector3 lightPos = new Vector3(calcPos_x, calcPos_y, calcPos_z);

            Debug.Log(i + " " + lightPos);

            lights[i] = Instantiate(light, lightPos, Quaternion.Euler(90f, 0f, 0f), transform);
        }
    }

    public void destroy()
    {
        for (int i = 0; i < count_x; i++)
        {
            for (int j = 0; j < count_z; j++)
            {
                DestroyImmediate(models[i, j]);
                DestroyImmediate(lights[i]);
            }
        }
    }

    public GameObject[,] getModels()
    {
        return models;
    }
    
    public GameObject[] getLights()
    {
        return lights;
    }
}
