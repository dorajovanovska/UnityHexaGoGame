using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//FEEDBACK: ako ovo ceka na trajanje videa, moguce je referencirati video i cekati koliko on traje
//          tako da onda ne moras rucno postavljati tu vrijednost kada se video mijenja
public class WaitForIntro : MonoBehaviour
{
    public float intro_duration = 7.0f;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(intro_duration);
        //FEEDBACK: izbjegavati hard kodirane broje, koristiti parametre za loadanje scena
        SceneManager.LoadScene(1);
    }
}
