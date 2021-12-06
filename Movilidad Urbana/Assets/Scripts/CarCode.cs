using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCode : MonoBehaviour
{

    public GameObject vehicle;
    public GameObject[] streets;
    public List<int> assigned = new List<int>();
    public List<GameObject> created = new List<GameObject>();
    public int number,vehicles = 4;
    private Vector3 scaleChange = new Vector3(0.1f,0.1f,0.1f);
    private Vector3 positionChange1x = new Vector3(-0.2f, 0f, 0f), positionChange2x = new Vector3(0.2f,0f,0f);
    private Vector3 positionChange1z = new Vector3(0f, 0f, -0.2f), positionChange2z = new Vector3(0f, 0f, 0.2f);
    public float xAngle, yAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {
        streets = GameObject.FindGameObjectsWithTag("street");
        vehicle.transform.localScale = scaleChange;

        for (int ctr = 0;ctr <= vehicles;ctr++)
        {
            int number = RandomGenerator(streets.Length);
            Vector3 position = streets[number].transform.position;
            position += new Vector3(0f, 0.1f, 0f);
            created.Add(Instantiate(vehicle, position, Quaternion.identity));
        }
        initializeMovement();
    }

    public int RandomGenerator(int length)
    {
        number = Random.Range(0, length);
        while(assigned.Contains(number))
        {
            number = Random.Range(0, length);
        }
        assigned.Add(number);
        return number;
    }

    public void initializeMovement()
    {
        bool orientation = true;
        for (int ctr = 0;ctr < created.Count;ctr++)
        {
            GameObject street = streets[assigned[ctr]];
            if(street.transform.rotation.eulerAngles.y == 90)
            {
                if (orientation)
                {
                    created[ctr].transform.Rotate(0f, 180f, 0f, Space.Self);
                    created[ctr].transform.position += positionChange1x;
                }
                else
                {
                    created[ctr].transform.Rotate(0f, 0f, 0f, Space.Self);
                    created[ctr].transform.position += positionChange2x;
                }
            }
            else
            {
                if (orientation)
                {
                    created[ctr].transform.Rotate(0f, 90f, 0f, Space.Self);
                    created[ctr].transform.position += positionChange1z;
                }
                else
                {
                    created[ctr].transform.Rotate(0f, -90f, 0f, Space.Self);
                    created[ctr].transform.position += positionChange2z;
                }
            }
            orientation = !orientation;
        }
    }
}