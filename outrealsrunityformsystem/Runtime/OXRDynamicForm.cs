/*
 * Card: Create Dynamic Support Form
 * 
 * Description - Created the Dynamic for to detect all the UI 
 * 
 * Developer - Anurag & Arup Kumar Sen
 * 
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

namespace oxrDynamicSupportForm
{

	public class OXRDynamicForm : MonoBehaviour
	{

		
		public GameObject UiType; //this is form which contain child object of XYZ UI-Type

		public List<GameObject> UiComponents; //This object will contain all the TYPE OF UI Segregated

		public Dictionary<InputField, string> InputField_Data = new Dictionary<InputField, string>();

		public Dictionary<Slider, int> Slider_Data = new Dictionary<Slider, int>();

		public Dictionary<Toggle, bool> Toggle_Data = new Dictionary<Toggle, bool>();

		public Dictionary<Dropdown, string> Dropdown_Data = new Dictionary<Dropdown, string>();

		public List<Button> button_Data = new List<Button>();

		SaveDataClass _saveDataClass;
		
		enum INPUTTYPE { INPUT, TOGGLE, SLIDER, DROPDOWN, BUTTON }
		INPUTTYPE iType;
		// Start is called before the first frame update


		private void Awake()
		{
			SaveSystem.init();
		}

		void Start()
		{
			//Getting all the children of Form and assigning it to a Gameobject list

			for (int i = 0; i < UiType.transform.childCount; i++)
			{
				GameObject Go = UiType.transform.GetChild(i).gameObject;

				UiComponents.Add(Go);
			}

		}


		public void SavetoJson()
		{

			//Serialize class to fetch the data from all the UI-Fileds
			_saveDataClass = new SaveDataClass();

			//Getting all the UI object from the UICOmponents 			

			foreach (var item in UiComponents)
			{
				if (item.GetComponent<InputField>() != null)
				{
					InputField iField = item.GetComponent<InputField>();

					_saveDataClass.InputText.Add(iField.text.ToString());

					Debug.Log("Data is coming " + iField.text);

					iType = INPUTTYPE.INPUT;
				}

				else if (item.GetComponent<Slider>() != null)
				{
					Slider _slider = item.GetComponent<Slider>();

					_saveDataClass.SliderText.Add( Mathf.RoundToInt(_slider.value * 100f));

					iType = INPUTTYPE.SLIDER;

				}

				else if (item.GetComponent<Toggle>() != null)
				{
					Toggle _Toggle = item.GetComponent<Toggle>();

					_saveDataClass.ToggleText.Add(_Toggle.isOn);

					iType = INPUTTYPE.TOGGLE;


				}
				else if (item.GetComponent<Dropdown>() != null)
				{
					Dropdown _DropDown = item.GetComponent<Dropdown>();

					_saveDataClass.DrowdownText.Add(_DropDown.value.ToString());

					iType = INPUTTYPE.DROPDOWN;
				}

				else
				{
					Button _BUtton = item.GetComponent<Button>();

					iType = INPUTTYPE.BUTTON;
				}

				#region If in future need Switch CASE

				//switch (iType)
				//{
				//	case INPUTTYPE.INPUT:	


				//		break;
				//	case INPUTTYPE.TOGGLE:

				//		//if we have TOggle then perform this



				//		break;
				//	case INPUTTYPE.DROPDOWN:

				//		//if we have Dropdown then perform this


				//		break;
				//	case INPUTTYPE.SLIDER:

				//		//if we have Slider then perform this


				//		break;

				//	case INPUTTYPE.BUTTON:

				//		//if we have Button then perform this

				//		break;

				//	default:
				//		break;

				//}

				#endregion
			}

			string SavedFile = JsonUtility.ToJson(_saveDataClass);

			SaveSystem.Save(SavedFile);

		}



		[SerializeField]
		public class SaveDataClass
		{
			public List<string> InputText = new List<string>();
			public List<bool> ToggleText = new List<bool>();
			public List<int> SliderText = new List<int>();
			public List<string> DrowdownText = new List<string>();
			
		}

	}
}
