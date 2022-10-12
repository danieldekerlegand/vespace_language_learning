using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SuperTitles : MonoBehaviour
{

    private class SuperTitleHelper
    {
        public float minute;
        public float second;
        public float time;
        public string dialogue;

        public SuperTitleHelper(float minute, float second, string dialogue){
            this.minute = minute;
            this.second = second;
            this.time = minute * 60 + second;
            this.dialogue = dialogue;
        }
    }

    float currentTimeElapsed;
    bool timerStarted;
    public Text textField;
    List<SuperTitleHelper> linesOfDialogue = new List <SuperTitleHelper>();
    SuperTitleHelper currentLine;
    SuperTitleHelper nextLine;
    int nextLineIndex;

    // Start is called before the first frame update
    void Start()
    {
        linesOfDialogue.Add(new SuperTitleHelper(0f, 0f, "I've got the floor!"));
        linesOfDialogue.Add(new SuperTitleHelper(0f, 10f, "Cupid decided to critique all the theatres last week, and I in turn will do the same..."));
        linesOfDialogue.Add(new SuperTitleHelper(0f, 23f, "Polichinelle's theatre is the noblest of the Fair, and that's a fact!"));
        linesOfDialogue.Add(new SuperTitleHelper(0f, 29f, "The rope dancers shut their trap, they did well to keep quiet. The Opéra-Comique blabbered on and on, and he should have just shut up."));
        linesOfDialogue.Add(new SuperTitleHelper(0f, 47f, "My fellow theatres, the other Polichinelles, made way for me. Thus, it is fair that I make the decisions as sovereign."));
        linesOfDialogue.Add(new SuperTitleHelper(1f, 6f, "Here comes the Opéra. Let's start with him."));
        linesOfDialogue.Add(new SuperTitleHelper(1f, 11f, "Hello, Polichinelle my friend. They say that your parody of Persée is quite funny."));
        linesOfDialogue.Add(new SuperTitleHelper(1f, 21f, "I just saw it. Are you roasting me too?"));
        linesOfDialogue.Add(new SuperTitleHelper(1f, 28f, "I've been doing it for a long time. You provide me with plenty of sticks to beat you with."));
        linesOfDialogue.Add(new SuperTitleHelper(1f, 36f, "What's that piece of paper you have? Is it a play for the new season?"));
        linesOfDialogue.Add(new SuperTitleHelper(1f, 47f, "These are the bills from Persée. The expenses from the tailors alone are bankrupting me."));
        linesOfDialogue.Add(new SuperTitleHelper(1f, 59f, "The ball made you rich. Those who danced at your ball paid for the violins."));
        linesOfDialogue.Add(new SuperTitleHelper(2f, 07f, "My parody cost just as much as your play to put on. My monster is more beautiful than yours."));
        linesOfDialogue.Add(new SuperTitleHelper(2f, 27f, "Why let me boast about it. My actresses are well dressed and deliciously beautiful."));
        linesOfDialogue.Add(new SuperTitleHelper(2f, 38f, "As much as an actress made of wood can be, I suppose."));
        linesOfDialogue.Add(new SuperTitleHelper(2f, 43f, "If my actresses were made of flesh like yours, say goodbye to their figure! There's always something to improve in a real woman."));
        linesOfDialogue.Add(new SuperTitleHelper(2f, 54f, "Is the show starting soon?"));
        linesOfDialogue.Add(new SuperTitleHelper(2f, 59f, "My opera resembles your own. Get yourself a good seat, the Opéra is the prince of all performances."));
        linesOfDialogue.Add(new SuperTitleHelper(3f, 11f, "And the performance of princes."));
        linesOfDialogue.Add(new SuperTitleHelper(3f, 17f, ""));
        linesOfDialogue.Add(new SuperTitleHelper(3f, 32f, "What does this fat queen want from me?"));
        linesOfDialogue.Add(new SuperTitleHelper(3f, 39f, "Ah, It's the Comédie-Française! We all know that she makes her dough with the public."));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 01f, "I have come to relax after my noble labors."));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 07f, "The Opéra is much more popular, it is open called the cousin of the Opéra-Comique. The Opéra is even paid to help handle the embarrassment."));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 20f, "So, are you coming to see my parody?"));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 25f, "I'm counting on laughing at it."));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 30f, "You seem to be very pleased with yourself."));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 33f, "I had a good haul. Despite my arrogance, the finest poets bring me their work with respect. \n \n That's what's ruining you."));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 46f, "Go take a seat near the Opéra, you two can go hand in hand."));
        linesOfDialogue.Add(new SuperTitleHelper(4f, 52f, "If I'm pleased, I will grant you my protection and you can count on my friendship."));
        linesOfDialogue.Add(new SuperTitleHelper(5f, 02f, "Seems like you learned your lesson from The School of Friends. We will see about that."));
        linesOfDialogue.Add(new SuperTitleHelper(5f, 09f, "Here comes the Comédie-Italienne. The gang will all be here now."));


        nextLineIndex = 1;
        currentLine = linesOfDialogue[0];
        nextLine = linesOfDialogue[nextLineIndex];
        timerStarted = false;   
        currentTimeElapsed = 0f;
        StartTimer();

    }

    // Update is called once per frame
    void Update()
    {
        if(timerStarted){
            currentTimeElapsed += Time.deltaTime;
        }

        textField.text = "time elapsed: " + currentTimeElapsed;

        textField.text += "\n\n\n" + currentLine.dialogue;

        if(currentTimeElapsed >= nextLine.time){
            nextLineIndex++;
            currentLine = nextLine;
            if(nextLineIndex < linesOfDialogue.Count){
                nextLine = linesOfDialogue[nextLineIndex];
            }
        }
    }

    public void StartTimer(){
        timerStarted = true;
    }

}
