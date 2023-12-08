using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float maxHP = 5;
    private float currentHP;
    private int currentSceneNum;
    void Start()
    {
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        currentHP = maxHP;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   IEnumerator Die()
       {
           anim.SetTrigger("Die");
           yield return new WaitForSeconds(5);
           SceneManager.LoadScene(currentSceneNum);
       }

    public void TakeDamage(int damage)
    {
        anim.SetTrigger("Hurt");
        currentHP -= damage;
        if (currentHP <= 0)
        {
            StartCoroutine("Die");
        }
    }
    
    
}
