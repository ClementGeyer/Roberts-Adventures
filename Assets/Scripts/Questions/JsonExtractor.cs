using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using TMPro;
 


[System.Serializable]
public class Question
{
    public string Titre;
    public string Q1;
    public string Q2;
    public string Q3;
    public string Q4;
    public string Rep;
}

[System.Serializable]
public class Questions{
    public Question[] questions;
}


public class JsonExtractor : MonoBehaviour
{
    [SerializeField]  private TextAsset jsonFile;
    [SerializeField]  private TextMeshProUGUI Question;
    [SerializeField]  private TextMeshProUGUI Q1Text;
    [SerializeField]  private TextMeshProUGUI Q2Text;
    [SerializeField]  private TextMeshProUGUI Q3Text;
    [SerializeField]  private TextMeshProUGUI Q4Text;

    private Questions QuestionsJson;
    private Question m_question;
    private int isTrue;

    void Start()
    {
        isTrue = 0;

        DieQuestion();
    }

    public void DieQuestion()
    {
        isTrue = 0;
        int nbQuestions = 0;

        //On deserialise le Json contenant les réponses
        QuestionsJson= JsonUtility.FromJson<Questions>(jsonFile.text);

        //On récupère la taille totale des questions, cad le nombre de questions
        nbQuestions = QuestionsJson.questions.Length;

        //On prends un nombre random qui nous donnera un numéro de question au pif
        nbQuestions = Random.Range(1, nbQuestions);

        //On boucle dans toutes les questions..
        foreach (Question q in QuestionsJson.questions)
        {
            nbQuestions--;
            //..Jusqu'à trouver la question que l'on cherchait
            if(nbQuestions == 0){

                //Ensuite on applique les résultats aux textes de questions
                m_question = q;
                Question.text = m_question.Titre;
                Q1Text.text = m_question.Q1;
                Q2Text.text = m_question.Q2;
                Q3Text.text = m_question.Q3;
                Q4Text.text = m_question.Q4;
            }
        }
    }

    //Permet de regarder si notre réponse est la bonne
    public void checkIfTrue( TextMeshProUGUI TextMesh ){

        if(m_question.Rep == TextMesh.text)
        {
            isTrue = 1;
        }
        else{
            isTrue = -1;
        }
    }

    public int userFindTrueRep(){
        return isTrue;
    }

}
