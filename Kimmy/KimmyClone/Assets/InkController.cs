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
    //private string text;
    public int ColorNum = 0;

    public GameObject buttonPanel;
    public GameObject textPanel;

    public Image imageScript;


    private void Start()
    {
        story = new Story(_inkJsonAsset.text);
        //RemoveChildren();
        source2.PlayOneShot(backgroundMusic);
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

        //Debug.Log("Did you get here?");

            
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
            Debug.Log("Did you see Dana?");
            ColorNum = 1;
            //DanaColor = new Color(156, 0, 255);
            //Debug.Log("Dana");
        }

        else if (text.Contains("Dana's Mom:"))
        {
            ColorNum = 2;
            // DanaMomColor = new Color(160, 112, 255);
            //Debug.Log("Mom");
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
        
        firstPlay = false;
        if (story.currentChoices.Count > 0)
        {

            //choiceThere = true;
            //if (choiceThere)
            //{
            // Debug.Log("How about here?");
            //Debug.Log(story.currentChoices.Count);

            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                //Debug.Log(story.currentChoices.Count);

                Choice choice = story.currentChoices[i];

                //if (!choiceThere)
                //{

                    Button button = CreateChoiceView(choice.text.Trim());
                    //Debug.Log(story.currentChoices.Count);
                    // Tell the button what to do when we press it

                    button.onClick.AddListener(delegate
                    {
                        source.PlayOneShot(click);
                        OnClickChoiceButton(choice);

                    });
                    // }

                //}
            }
        }
        else if (!firstPlay && story.currentChoices.Count < 0){
            Button choice = CreateChoiceView("Play Again?");
            choice.onClick.AddListener(delegate {
                SceneManager.LoadScene("SampleScene");
            });
        }
      
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);

        //string text = story.Continue();
        //text = text.Trim();
        //CreateContentView(text);
        //RemoveChildren();
        addText();
        choiceThere = false;
    }

    // Creates a button showing the choice text
    void CreateContentView(string text)
    {
        //Debug.Log("Hi are you creating content?");
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;

        if(ColorNum == 0){
            imageScript.color = NarrativeColor;
        }

        else if (ColorNum == 1)
        {
            //DanaColor = 156, 0, 255, 255;
            //storyText.color = DanaColor;
            imageScript.color = DanaColor;
            ColorNum = 0;
        }
        else if (ColorNum == 2)
        {
            //DanaMomColor = 160, 112, 255, 255;
            imageScript.color = DanaMomColor;
            //ColorNum = 0;
        }
        else if (ColorNum == 3)
        {
            //KimmyColor = 255, 0, 236, 255;
            imageScript.color = KimmyColor;

            ColorNum = 0;
        }
        else if (ColorNum == 4)
        {
            //KimmyMomColor = 255, 143, 227, 255;
            imageScript.color = KimmyMomColor;
            ColorNum = 0;
        }
        else if (ColorNum == 5)
        {
            //DeanColor = 255, 79, 0, 255;
            imageScript.color = DeanColor;
            ColorNum = 0;
        }
        else if (ColorNum == 6)
        {
            //AnthonyColor = 255, 0, 62, 255;
            imageScript.color = AnthonyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 7)
        {
            //AmberColor = 24, 132, 0, 255;
            imageScript.color = AmberColor;
            ColorNum = 0;
        }
        else if (ColorNum == 8)
        {
            //DonnaColor = 212, 190, 0, 255;
            imageScript.color = DonnaColor;
            //ColorNum = 0;
        }
        else if (ColorNum == 9)
        {
            //HaroldColor = 8, 0, 176, 255;
            imageScript.color = HaroldColor;
            ColorNum = 0;
        }
        else if (ColorNum == 10)
        {
            //JaneyColor = 0, 255, 255, 255;
            imageScript.color = JaneyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 11)
        {
            //JimmyColor = 123, 0, 3, 255;
            imageScript.color = JimmyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 12)
        {
            //LindaColor = 109, 109, 109, 255;
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
