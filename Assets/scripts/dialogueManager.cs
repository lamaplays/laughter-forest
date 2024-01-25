using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class dialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueParent;
    [SerializeField] private TMP-Tent dialogueText;
    [SerializeField] private Button option1Button;
    [SerializeField] private Button option2Button;

    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField]  private float turningSpeed = 2f;
    private list<dialogueString> dialongueList;
    private int currentDialogueIndex = 0;

    private void Start()
    {
        dialogueParent.SetActive(false);
        PlayerCamera = Camera.main.transform;

    }
    public void DialogueStart(list <dialogueString> testToPoint, Transfrom NPC)
    {
        dialogueParent.SetActive(true);
        FirstPersonController.enabled = false;
        Cursor.lookState = CursorLockMode.None;
        Cursor.visible = true;

        StartCorotine(TurnCameraTowardsNPC(NPC));
        dialogueList = textToPrint;     
        currentDialogueIndex = 0;
        DisableButton();
        StartCoroutine(PrintDialogue());

    }

   private void DisableButtons()
    {
        option1Button.interactable = false;
        option2Button.interactable = false;

        option1Button.GetComponentInChildren<TMP_Text>().text = "No option";
        option2Button.GetComponentInChildren<TMP_Text>().text = "No option";
        

    }

    private IEnumerator TurnCameeraTowardsNPC(Transform NPC)
    {
        Quaternion startRotation = playerCamera.rotation;
        quaterion targetRotation = quaternion.LookRotation(NPC.position - playerCamera.position);

        flaot elapsedTime = 0f;
        while (elapsedTime< 1f )
        {
            playerCamera.rotation  = Quaterion.Slerp(startRotation, targetRotation,elapsedTime);
            elapsedTime += Time.deltaTime * turnSpeed;
            yield return null;  
                
        }
        playerCamera.rotation = targetRotation;

    }
    private IEnumerator PrintDialongue()
    {
        while (currentDialogueIndex < dialogueList.Count)
        {
            diallogueString line = dialongueList[currentDialogueIndex];
            if(line.isQuestion)
            {

            }
            else
            {
                yield return StartCoroutine(TypeText(line.text));  
            }
        }
    }

}
