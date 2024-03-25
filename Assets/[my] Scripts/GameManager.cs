using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class GameManager : MonoBehaviour
{
    public GameObject ObjectParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void save_gameobjects()
    {
        string filePath = Application.persistentDataPath + "/SavedObjects.csv";
        // save all gameobjects under ObjectParent to a csv file
        Debug.Log(filePath);
        var csv = new StringBuilder();
        // save transform of each object as JSON
        foreach (Transform child in ObjectParent.transform)
        {
            var line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}\n",
                               child.position.x, child.position.y, child.position.z,
                               child.rotation.x, child.rotation.y, child.rotation.z,
                               child.localScale.x, child.localScale.y, child.localScale.z,
                               child.gameObject.name, child.GetComponent<InteractableObject>().obj_type);
            csv.AppendLine(line);
        }

        //after your loop
        File.WriteAllText(filePath, csv.ToString());
        PopUpToolTip.Instance.add_pop_up("Scene file saved!");
    }
}
