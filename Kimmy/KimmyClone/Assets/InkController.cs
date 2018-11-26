using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkController : MonoBehaviour {
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

    public int ColorNum = 0;
    void Awake()
    {
        // Remove the default message
        RemoveChildren();
        StartStory();
    }

    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        RefreshView();
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            //Debug.Log("This is working");
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();

            if (text.Contains("Dana:"))
            {
                ColorNum = 1;
               //Debug.Log("Dana");
            }

            else if (text.Contains("Mom:"))
            {
                ColorNum = 2;
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

            // Display the text on screen!
            CreateContentView(text);
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            Button choice = CreateChoiceView("End of story.\nRestart?");
            choice.onClick.AddListener(delegate {
                StartStory();
            });
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    // Creates a button showing the choice text
    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;

        //if(ColorNum == 0){
        //    storyText.color = new Color(255, 255, 255);
        //}

        if (ColorNum == 1)
        {
            //Debug.Log("Dana");
            DanaColor = new Color(156, 0, 255);
            storyText.color = DanaColor;
            //ColorNum = 0;
        }
        if (ColorNum == 2)
        {
            //Debug.Log("Mom");
            DanaMomColor = new Color(160, 112, 255);
            storyText.color = DanaMomColor;
            //ColorNum = 0;
        }
        if (ColorNum == 3)
        {
            KimmyColor = new Color(255, 0, 236);
            storyText.color = KimmyColor;
            ColorNum = 0;
        }
        if (ColorNum == 4)
        {
            KimmyMomColor = new Color(255, 143, 227);
            storyText.color = KimmyMomColor;
            ColorNum = 0;
        }
        else if (ColorNum == 5)
        {
            DeanColor = new Color(255, 79, 0);
            storyText.color = DeanColor;
            ColorNum = 0;
        }
        else if (ColorNum == 6)
        {
            AnthonyColor = new Color(255, 0, 62);
            storyText.color = AnthonyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 7)
        {
            AmberColor = new Color(24, 132, 0);
            storyText.color = AmberColor;
            ColorNum = 0;
        }
        else if (ColorNum == 8)
        {
            DonnaColor = new Color(212, 190, 0);
            storyText.color = DonnaColor;
            //ColorNum = 0;
        }
        else if (ColorNum == 9)
        {
            HaroldColor = new Color(8, 0, 176);
            storyText.color = HaroldColor;
            ColorNum = 0;
        }
        else if (ColorNum == 10)
        {
            JaneyColor = new Color(255, 167, 0);
            storyText.color = JaneyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 11)
        {
            JimmyColor = new Color(123, 0, 3);
            storyText.color = JimmyColor;
            ColorNum = 0;
        }
        else if (ColorNum == 12)
        {
            LindaColor = new Color(109, 109, 109);
            storyText.color = LindaColor;
            ColorNum = 0;
        }

        storyText.transform.SetParent(canvas.transform, false);
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(canvas.transform, false);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }

    [SerializeField]
    private TextAsset inkJSONAsset;
    private Story story;

    [SerializeField]
    private Canvas canvas;

    // UI Prefabs
    [SerializeField]
    private Text textPrefab;
    [SerializeField]
    private Button buttonPrefab;
}
