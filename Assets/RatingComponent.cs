using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using UnityEngine;

public class RatingComponent : MonoBehaviour
{
    private const string c_ConfigPath = "//Resources//PlayerRating.xml";

    [SerializeField]
    private RatingField _prefab;

    [SerializeField]
    private List<RatingField> ratings=new();

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            var t = Instantiate(_prefab, transform);
            t.gameObject.SetActive(false);
            ratings.Add(t);
        }
    }


    private void OnEnable()
    {
        OpenRating();
    }

    private void OpenRating()
    {
        CloseRating();
        var doc=XDocument.Load(Application.dataPath + c_ConfigPath);
        if (doc == null) return;
        int i = 0;
        foreach (var player in doc.Root.Elements("Player"))
        {
            i++;
            if (i <= 10)
            {
                string name = (string)player.Attribute("Name");
                float time = (float)player.Attribute("Time");
                var t = ratings.First(t => !t.gameObject.activeSelf);
                t.gameObject.SetActive(true);
                t.Set(i.ToString(), name, time);
            }
            else
                break;
        }

        SortRating();
    }


    private void CloseRating()
    {
        foreach (var rating in ratings)
            rating.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CloseRating();
    }

    public void AddRating(string name, float time)
    {
        XDocument xdoc = new XDocument();
        XElement Players = new("Players");

        var t = ratings.First(t => !t.gameObject.activeSelf);
        t.gameObject.SetActive(true);
        t.Set("", name, time);
        SortRating();
        foreach (var rating in ratings.Where(t => t.gameObject.activeSelf))
        {
            XElement player = new("Player");
            XAttribute Name = new("Name", rating.PlayerName);
            XAttribute Time = new("Time", rating.Time);
            player.Add(Name, Time);
            Players.Add(player);
        }
        xdoc.Add(Players);
        
        xdoc.Save(Application.dataPath + c_ConfigPath);
        OpenRating();
    }

    private void SortRating()
    {
        for (int i = 0; i < ratings.Count; i++) {
            for (int y = i + 1; y < ratings.Count; y++)
            {
                if (ratings[i].Time >= ratings[y].Time && (ratings[i].Time != 0f && ratings[y].Time != 0f))
                {
                    string name = ratings[i].PlayerName;
                    float time = ratings[i].Time;
                    ratings[i].Set("", ratings[y].PlayerName, ratings[y].Time);
                    ratings[y].Set("", name, time);
                }
            }
        }


    }
}
