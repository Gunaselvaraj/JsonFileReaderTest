using UnityEngine;
using TMPro;

public class JsonReader : MonoBehaviour
{
    public TextAsset JSonFileNeeded;
    
    //Custom Class to Store the Info from Json File it should contain the same field names 
    //the Varaibles Should Contain the Extact naming as in Json file
    [System.Serializable]
    public class Colors
    {
        public string name;
        public string hex;
    }
    
    //Creating a List to Hold All the Datas from Json
    [System.Serializable]
    public class ColorsList
    {
        public Colors[] Color;
    }
    
    public ColorsList MycolorList = new ColorsList();
    
    //Inspector Input
    public Material RefMaterial; //Material to Test
    public TextMeshPro TextinScreen; //Text reference to load the input 
    public bool isChangeColor;  
    private Color ColorData;  //to store the Hex data
    string ChoosedColorHexValue, ChoosedColorName; 
    
    void Start()
    {
        isChangeColor = false;
        //loading the Json data into list
        MycolorList = JsonUtility.FromJson<ColorsList>(JSonFileNeeded.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (isChangeColor)
        {
            ChangeColorofMaterial();
            isChangeColor = false;
        }
    }

    //Picking a Random Color Every Time Player Clicks on the isChangeColor bool in Inspector
    string RandomColorpicker()
    {
        int num = Random.Range(0, MycolorList.Color.Length);
        print(num);
        ChoosedColorName = MycolorList.Color[num].name;
        ChoosedColorHexValue = MycolorList.Color[num].hex;
        return ChoosedColorName;
        //return ChoosedColorHexValue;
    }

    //Actual Function that Changes the Color in Given Material
    void ChangeColorofMaterial()
    {
        TextinScreen.text = RandomColorpicker();
        ColorUtility.TryParseHtmlString(ChoosedColorHexValue, out ColorData);
        RefMaterial.color = ColorData;
    }
}
