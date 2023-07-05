using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }

    public List<GameObject> PotentialHeists;
    public GameObject DefaultHeist;
    public List<GameObject> Plots;

    public List<GameObject> InstantiatedHeists = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void InitialiseBuildings()
    {
        int amountOfPlots = Plots.Count;

        if (amountOfPlots == 0)
            return;

        if (amountOfPlots > 1)
            RandomiseList<GameObject>(Plots);

        int takenPlots = 0;

        if (takenPlots < amountOfPlots)
        {
            foreach (GameObject heistPrefab in PotentialHeists)
            {
                InstantiatePlot(heistPrefab, Plots[takenPlots]);
                takenPlots++;
            }

            if (DefaultHeist == null)
            {
                return;
            }

            while (takenPlots < amountOfPlots)
            {
                InstantiatePlot(DefaultHeist, Plots[takenPlots]);

                Debug.Log("Room left adding default");
                takenPlots++;
            }
        }
    }

    public void DestroyBuildings()
    {
        foreach (GameObject heist in InstantiatedHeists)
        {
            Destroy(heist);
            InstantiatedHeists.Remove(heist);
        }
    }

    private void InstantiatePlot(GameObject heistPrefab, GameObject plot)
    {
        Transform plotPosition = plot.transform;
        GameObject heistGameObject = Instantiate(heistPrefab, plotPosition);
        InstantiatedHeists.Add(heistGameObject);
    }

    private void RandomiseList<T>(List<T> list)
    {
        int count = list.Count;

        int last = count - 1;

        for (int i = 0; i < last; i++)
        {
            int random = Random.Range(i, count);
            GameObject temp = Plots[i];
            Plots[i] = Plots[random];
            Plots[random] = temp;
        }
    }
}
