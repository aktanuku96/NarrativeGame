using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class InkController : MonoBehaviour
{
    public Color NarrativeColor;
    public Color DanaColor;
    public Color DanaMomColor;
    public Color KimmyColor;
    public Color KimmyMomColor;
    public Color DeanColor;
    public Color AnthonyColor;
    public Color AmberColor;
    public Color DonnaColor;
    public Color HaroldColor;
    public Color JaneyColor;
    public Color JimmyColor;
    public Color LindaColor;

    public AudioClip click;
    public AudioSource source;

    public AudioClip backgroundMusic;
    public AudioSource source2;

    public GameObject KimmyPrefab;
    public GameObject DanaPrefab;
    public GameObject DanaMomPrefab;
    public GameObject KimmyMomPrefab;
    public GameObject NeighborhoodPrefab;
    public GameObject KimmysPrefab;

    private Vector3 KimmyStartPos;
    private Vector3 DanaStartPos;
    private Vector3 DanaMomStartPos;
    private Vector3 KimmyMomStartPos;
    private Vector3 NeighborhoodStartPos;
    private Vector3 KimmysStartPos;

    private GameObject Kimmytemp;
    private GameObject Danatemp;
    private GameObject DanaMomtemp;
    private GameObject KimmyMomtemp;
    private GameObject Neighborhoodtemp;
    private GameObject Kimmystemp;

    private bool isPlayground;
    private bool isKimmysHouse;
    private bool isHome;
    private bool isDowntown;
    private bool isKimmysHousebeginning;

    private bool visitedPlayground;
    private bool visitedKimmys;
    private bool visitedHome;
    private bool visitedDowntown;

    public GameObject LindaPrefab;
    public GameObject JaneyPrefab;
    public GameObject PlayGroundPrefab;

    private GameObject Lindatemp;
    private GameObject Janeytemp;
    private GameObject PlayGroundtemp;

    private Vector3 LindaStartPos;
    private Vector3 JaneyStartPos;
    private Vector3 PlaygroundStartPos;

    public GameObject DeanPrefab;
    public GameObject DonnaPrefab;

    private GameObject Deantemp;
    private GameObject Donnatemp;

    private Vector3 DeanStartPos;
    private Vector3 DonnaStartPos;

    public GameObject HaroldPrefab;
    private GameObject Haroldtemp;
    private Vector3 HaroldStartPos;

    public GameObject AnthonyandAmberPrefab;
    public GameObject DowntownPrefab;
    public GameObject JimmyPrefab;

    private GameObject AnthonyandAmbertemp;
    private GameObject Jimmytemp;
    private GameObject Downtowntemp;

    private Vector3 AnthonyandAmberStartPos;
    private Vector3 JimmyStartPos;
    private Vector3 DowntownStartPos;

    [SerializeField] private TextAsset _inkJsonAsset;
    [SerializeField] private Story story;

    [SerializeField]
    private Canvas canvas;

    // UI Prefabs
    [SerializeField]
    private Text textPrefab;
    [SerializeField]
    private Button buttonPrefab;


    private bool choiceThere;
    private bool firstPlay = true;
   
    public int ColorNum = 0;

    public GameObject buttonPanel;
    public GameObject textPanel;

    public Image imageScript;


    private void Start()
    {
        story = new Story(_inkJsonAsset.text);
      
        source2.PlayOneShot(backgroundMusic);


        visitedPlayground = false;
        visitedKimmys = false;
        visitedHome = false;
        visitedDowntown = false;
    
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            addText();
        }
            
        if(!choiceThere){

            ShowChoices();

        }
        else { return; }
     }




void addText()
{
    if (story.canContinue)
    {
        RemoveChildren();
        string text = story.Continue();
        text = text.Trim();

        if (text.Contains("Dana:"))
        {
            ColorNum = 1;
            
        }

        else if (text.Contains("Dana's Mom:"))
        {
            ColorNum = 2;
           
        }

        else if (text.Contains("Kimmy:"))
        {
            ColorNum = 3;
        }

        else if (text.Contains("Kimmy's Mom:"))
        {
            ColorNum = 4;
        }

        else if (text.Contains("Dean:"))
        {
            ColorNum = 5;
        }

        else if (text.Contains("Anthony:"))
        {
            ColorNum = 6;
        }

        else if (text.Contains("Amber:"))
        {
            ColorNum = 7;
        }

        else if (text.Contains("Donna:"))
        {
            ColorNum = 8;
        }

        else if (text.Contains("Harold:"))
        {
            ColorNum = 9;
        }

        else if (text.Contains("Janey:"))
        {
            ColorNum = 10;
        }

        else if (text.Contains("Jimmy:"))
        {
            ColorNum = 11;
        }

        else if (text.Contains("Linda:"))
        {
            ColorNum = 12;
        }
        
        else{
            ColorNum = 0;
        }

        CreateContentView(text);

    }
}


    void ShowChoices(){
        if (story.currentChoices.Count > 0)
        {
        
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
            
                Choice choice = story.currentChoices[i];

                //This marks the beginning of the intro portion
                if (choice.text.Contains("Talk to Mom"))
                {
                    Kimmytemp = Instantiate(KimmyPrefab);
                    Danatemp = Instantiate(DanaPrefab);
                    DanaMomtemp = Instantiate(DanaMomPrefab);
                    Neighborhoodtemp = Instantiate(NeighborhoodPrefab);

                    isHome = true;

                    KimmyStartPos = KimmyPrefab.transform.position;
                    DanaStartPos = DanaPrefab.transform.position;
                    DanaMomStartPos = DanaMomPrefab.transform.position;
                    NeighborhoodStartPos = NeighborhoodPrefab.transform.position;
                }

                if (story.currentText.Contains("Oh, don’t worry. Thank you for finding Kimmy and walking her home. What's your name, dear?"))
                {

                    Neighborhoodtemp.transform.position += new Vector3(100f, 0f, 0f);
                    isHome = false;
                    KimmyMomtemp = Instantiate(KimmyMomPrefab);
                    Kimmystemp = Instantiate(KimmysPrefab);
                    KimmyMomStartPos = KimmyMomPrefab.transform.position;
                    KimmysStartPos = KimmysPrefab.transform.position;
                    isKimmysHousebeginning = true;
                    //
                }
                else if (choice.text.Contains("It's the next day. You see Kimmy tied to the porch."))
                {
                   
                    DanaMomtemp.transform.position += new Vector3(100f, 0f, 0f);
                    KimmyMomtemp.transform.position += new Vector3(100f, 0f, 0f);
                    Kimmytemp.transform.position += new Vector3(5f, 0f, 0f);

                }

                //marks the end of the intro portion and now the player can go wherever they please
                else if (story.currentText.Contains("So Kimmy, where would you like to go now?"))
                {
                    Danatemp.transform.position = DanaStartPos;
                    Kimmytemp.transform.position = KimmyStartPos;

                    //is markers are used to move backgrounds off screen when in the map stage
                    if (isKimmysHousebeginning)
                    {
                        Kimmystemp.transform.position += new Vector3(100f, 0f, 0f);
                    }
                    else if (isHome)
                    {
                        Neighborhoodtemp.transform.position += new Vector3(100f, 0f, 0f);
                        Haroldtemp.transform.position += new Vector3(100f, 0f, 0f);
                        DanaMomtemp.transform.position += new Vector3(100f, 0f, 0f);
                    }

                    else if (isPlayground)
                    {
                        PlayGroundtemp.transform.position += new Vector3(100f, 0f, 0f);
                        Lindatemp.transform.position += new Vector3(100f, 0f, 0f);
                        Janeytemp.transform.position += new Vector3(100f, 0f, 0f);
                    }


                    else if (isKimmysHouse)
                    {
                        Kimmystemp.transform.position += new Vector3(100f, 0f, 0f);
                        Donnatemp.transform.position += new Vector3(100f, 0f, 0f);
                        Deantemp.transform.position += new Vector3(100f, 0f, 0f);
                    }

                    else if(isDowntown){
                        AnthonyandAmbertemp.transform.position += new Vector3(100f, 0f, 0f);
                        Jimmytemp.transform.position += new Vector3(100f, 0f, 0f);
                        Downtowntemp.transform.position += new Vector3(100f, 0f, 0f);
                    }

                    isHome = false;
                    isDowntown = false;
                    isKimmysHouse = false;
                    isPlayground = false;
                    isKimmysHouse = false;
                    isKimmysHousebeginning = false;
                }

                else if (choice.text.Contains("Talk to Linda!"))
                {
                    if (visitedPlayground)
                    {
                        Lindatemp.transform.position = LindaStartPos;
                        Janeytemp.transform.position = JaneyStartPos;
                        PlayGroundtemp.transform.position = PlaygroundStartPos;
                    }
                    else
                    {
                        PlayGroundtemp = Instantiate(PlayGroundPrefab);
                        Lindatemp = Instantiate(LindaPrefab);
                        Janeytemp = Instantiate(JaneyPrefab);

                        PlaygroundStartPos = PlayGroundPrefab.transform.position;
                        LindaStartPos = LindaPrefab.transform.position;
                        JaneyStartPos = JaneyPrefab.transform.position;
                        visitedPlayground = true;
                    }

                    isPlayground = true;

                }

                else if (choice.text.Contains("Talk to Donna!"))
                {
                    if (visitedKimmys)
                    {
                        Deantemp.transform.position = DeanStartPos;
                        Donnatemp.transform.position = DonnaStartPos;
                        Kimmystemp.transform.position = KimmysStartPos;
                    }
                    else
                    {
                        Kimmystemp.transform.position = KimmysStartPos;
                        Deantemp = Instantiate(DeanPrefab);
                        Donnatemp = Instantiate(DonnaPrefab);

                        DeanStartPos = DeanPrefab.transform.position;
                        DonnaStartPos = DonnaPrefab.transform.position;
                        visitedKimmys = true;
                    }
                    isKimmysHouse = true;

                }

                else if (choice.text.Contains("Talk to Harold!"))
                {
                    Neighborhoodtemp.transform.position = NeighborhoodStartPos;
                    DanaMomtemp.transform.position = DanaMomStartPos;
                    if (visitedHome)
                    {
                        Haroldtemp.transform.position = HaroldStartPos;
                    }
                    else
                    {
                        Haroldtemp = Instantiate(HaroldPrefab);
                    }
                    isHome = true;
                }

                else if (choice.text.Contains("Talk to Jimmy!"))
                {
                    if (visitedDowntown)
                    {
                        AnthonyandAmbertemp.transform.position = AnthonyandAmberStartPos;
                        Jimmytemp.transform.position = JimmyStartPos;
                        Downtowntemp.transform.position = DowntownStartPos;
                    }

                    else
                    {
                        AnthonyandAmbertemp = Instantiate(AnthonyandAmberPrefab);
                        Jimmytemp = Instantiate(JimmyPrefab);
                        Downtowntemp = Instantiate(DowntownPrefab);
                    }
                    isDowntown = true;
                }



                else if (choice.text.Contains("You walk over and say hi to Linda")){
                    Janeytemp.transform.position += new Vector3(100f, 0f, 0f);
                }

                else if(choice.text.Contains("You walk over and say hi to Janey")){
                    Lindatemp.transform.position += new Vector3(100f, 0f, 0f);
                }
                else if(choice.text.Contains("You walk in and see Dean")){
                    Donnatemp.transform.position += new Vector3(100f, 0f, 0f);
                }
                else if(choice.text.Contains("You walk over and say hi to Donna")){
                    Deantemp.transform.position += new Vector3(100f, 0f, 0f);
                }
                else if (choice.text.Contains("You see your mom"))
                {
                    Haroldtemp.transform.position += new Vector3(100f, 0f, 0f);
                }
                else if (choice.text.Contains("You walk over and say hi to Harold"))
                {
                    DanaMomtemp.transform.position += new Vector3(100f, 0f, 0f);
                }
                else if (choice.text.Contains("You walk over and see Jimmy"))
                {
                    AnthonyandAmbertemp.transform.position += new Vector3(100f, 0f, 0f);
                }
                else if (choice.text.Contains("You go over and say hi to Anthony and Amber"))
                {
                    Jimmytemp.transform.position += new Vector3(100f, 0f, 0f);
                }



                //End Day portion
                else if(choice.text.Contains("You walk over and say hi to Mrs. Munro")){
                    Kimmystemp.transform.position = KimmysStartPos;
                    KimmyMomtemp.transform.position = KimmyMomStartPos;

                }

                else if(choice.text.Contains("Mom?")){
                    DanaMomtemp.transform.position = DanaMomStartPos;

                }

                else if(choice.text.Contains("Walk home")){
                    //bye to Kimmy's family
                    KimmyMomtemp.transform.position += new Vector3(100f, 0f, 0f);
                    Kimmytemp.transform.position += new Vector3(100f, 0f, 0f);


                }

                else if(choice.text.Contains("Talk about Kimmy's rope")){
                    Kimmystemp.transform.position += new Vector3(100f, 0f, 0f);
                    Danatemp.transform.position = KimmyMomStartPos;
                    Neighborhoodtemp.transform.position = NeighborhoodStartPos;
                }
                else if(choice.text.Contains("Weird but okay?")){
                    Neighborhoodtemp.transform.position += new Vector3(3f, 0f, 0f);
                }
                else if (choice.text.Contains("Sure..."))
                {
                    Neighborhoodtemp.transform.position += new Vector3(2f, 0f, 0f);
                }
                else if (choice.text.Contains("Worry"))
                {
                    Neighborhoodtemp.transform.position += new Vector3(1f, 0f, 0f);
                }

                //The end

                Button button = CreateChoiceView(choice.text.Trim());

                    // Tell the button what to do when we press it

                    button.onClick.AddListener(delegate
                    {
                        source.PlayOneShot(click);
                        OnClickChoiceButton(choice);

                    });
                   

            }
        }

        //restart at the end of day 1
        else if (Input.GetKeyDown(KeyCode.Alpha1)){
            SceneManager.LoadScene("SampleScene");
        }
      
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        addText();
        choiceThere = false;
    }

    // Creates a button showing the choice text
    void CreateContentView(string text)
    {
      
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;

        if(ColorNum == 0){
            imageScript.color = NarrativeColor;
        }

        else if (ColorNum == 1)
        {
            imageScript.color = DanaColor;
            ColorNum = 0;
        }
        else if (ColorNum == 2)
        {
            imageScript.color = DanaMomColor;
        }
        else if (ColorNum == 3)
        {
            imageScript.color = KimmyColor;

            ColorNum = 0;
        }
        else if (ColorNum == 4)
        {
            imageScript.color = KimmyMomColor;
            ColorNum = 0;
        }
        else if (ColorNum == 5)
        {
            imageScript.color = DeanColor;
            ColorNum = 0;
        }
        else if (ColorNum == 6)
        {
            imageScript.color = AnthonyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 7)
        {
            imageScript.color = AmberColor;
            ColorNum = 0;
        }
        else if (ColorNum == 8)
        {
            imageScript.color = DonnaColor;
        }
        else if (ColorNum == 9)
        {
            imageScript.color = HaroldColor;
            ColorNum = 0;
        }
        else if (ColorNum == 10)
        {
            imageScript.color = JaneyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 11)
        {
            imageScript.color = JimmyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 12)
        {
            imageScript.color = LindaColor;
            ColorNum = 0;
        }

        storyText.transform.SetParent(textPanel.transform, false);
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(buttonPanel.transform, false);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        choiceThere = true;

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    void RemoveChildren()
    {
        int childCount = textPanel.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(textPanel.transform.GetChild(i).gameObject);
        }
        int childCountButton = buttonPanel.transform.childCount;
        for (int i = childCountButton - 1; i >= 0; --i)
        {
            GameObject.Destroy(buttonPanel.transform.GetChild(i).gameObject);
        }

    }

  


}
