using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class TextParser : MonoBehaviour
{
    public ActionHandler actionHandler;
    public TMP_InputField playerMessageInputField;
    public TextMeshProUGUI gameNarration;

    public Player player;

    void Start()
    {
        string welcomeMessage = "Welcome to EverHeart MUD. The current version is alpha 0.0.1. Type /help at any time to see an extensive list of explanations and commands on how to play. Best of luck on your journey!";
        PostTextToUI(welcomeMessage);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string playerInput = playerMessageInputField.text;
            ResolvePlayerInput(playerInput);
            
        }
    }

    void ResolvePlayerInput(string playerInput)
    {
        PostTextToUI("<i><color=#fbb03b><b>" + player.playerName + ": </b></color><color=#FED8B1>" + playerInput + "</color></i>");

        string[] parsedInput = playerInput.ToLower().Split(" ");
        string messageToPost = "";

        if (parsedInput.Length > 0)
            {
                messageToPost += actionHandler.GetInputAction(parsedInput);
            }

        PostTextToUI(messageToPost);
    }

    void PostTextToUI(string textToPost)
    {
        playerMessageInputField.text = "";
        gameNarration.text += textToPost + "\n\n";

        playerMessageInputField.ActivateInputField();
    }




}
