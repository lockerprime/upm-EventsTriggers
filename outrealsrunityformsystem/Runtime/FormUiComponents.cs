using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class FormUiComponents : MonoBehaviour
{
    public GameObject UiType;
    public List<GameObject> UiComponents;
    public Dictionary<InputField, string> InputField_Data = new Dictionary<InputField, string>();
 
    // Start is called before the first frame update

    List<string> InputformData = new List<string>();

    string filePath = Path.Combine(Application.streamingAssetsPath, "file.json");
    serilaizedData playerInstance = new serilaizedData();
    public void SetForm()
    {

         for (int i = 0; i < UiType.transform.childCount; i++)
        {
            UiComponents.Add(UiType.transform.GetChild(i).gameObject);
        }


        for (int i = 0; i < UiComponents.Count; i++)
        {
            if (UiComponents[i].GetComponent<InputField>() != null)
            {
                Debug.LogError("InputField");
                InputField val = UiComponents[i].GetComponent<InputField>();
                playerInstance.InputField.Add(val.text.ToString());  
            }
            else if (UiComponents[i].GetComponent<Slider>() != null)
            {
                Slider val = UiComponents[i].GetComponent<Slider>();
                playerInstance.Slider.Add(val.value.ToString());
                
            }
            else if (UiComponents[i].GetComponent<Button>() != null)
            {
                Button val = UiComponents[i].GetComponent<Button>();
                playerInstance.Button.Add(val.IsInteractable());
           
            }
            else if (UiComponents[i].GetComponent<Toggle>() != null)
            {

                Toggle val = UiComponents[i].GetComponent<Toggle>();
                playerInstance.Toggle.Add(val.isOn);
     
            }
            else if (UiComponents[i].GetComponent<Dropdown>() != null)
            {

                Dropdown val = UiComponents[i].GetComponent<Dropdown>();
                playerInstance.Dropdown.Add(val.value);

               
            }
            else
            {
                playerInstance.exception.Add("unmatched component");
            }
        }
        SavetoJson();
    }
    public void SavetoJson()
    {
         string json = JsonUtility.ToJson(playerInstance, true);
        Debug.LogError("the path" + Application.dataPath);
        File.WriteAllText(Application.dataPath + "/FormDataFile.json", json);
#if UNITY_EDITOR

      
#endif
#if UNITY_WEBGL
        File.WriteAllText(filePath, json);
#endif

    }


    [Serializable]
    public class serilaizedData
    {
        public List<string> InputField= new List<string>();
        public List<string> Slider = new List<string>();
        public List<bool> Button = new List<bool>();
        public List<bool> Toggle = new List<bool>();
        public List<int> Dropdown = new List<int>();
        public List<string> exception = new List<string>();
 

    }
}
