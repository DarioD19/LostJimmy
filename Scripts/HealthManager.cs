using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    
    
    private int maxLife = 5;
    [SerializeField]
    public  int _currentLife;
    public PlayerMovment thePlayer;
    [SerializeField]
    private float invincibilityLenght;
    private float _invicbilityCounter;
    public Renderer playerRenderer;
    private float _flashcounter;
    [SerializeField]
    private float flashLenght = 0.1f;
    [SerializeField] private GameObject _playerDeathEff;
    [SerializeField] private LifePanel _lifePanelPrefab;
    [SerializeField] private Transform _lifesGroup;
    private List<LifePanel> _lifePanelList = new List<LifePanel>();
    private int _lifeLose = 0;
    public Vector3 RespawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        _currentLife = maxLife;
        RespawnPosition = transform.position;
        
        
        

        for (int i = 0; i < _currentLife; i++)
        {
          LifePanel lifePanel =  Instantiate(_lifePanelPrefab, _lifesGroup);
            _lifePanelList.Add(lifePanel);
        }
       
        
        
        
        
        

    }

    // Update is called once per frame
    void Update()
    {
       
        if (_currentLife > 5)
        {
            _currentLife = maxLife;
            for (int i = 0; i < _currentLife; i++)
            {

               LifePanel lifePanel =  Instantiate(_lifePanelPrefab, _lifesGroup);
                _lifePanelList.Add(lifePanel);

            }
        }
      

        
        if (_invicbilityCounter > 0)
        {
            _invicbilityCounter -= Time.deltaTime;
            _flashcounter -= Time.deltaTime;
            if (_flashcounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                _flashcounter = flashLenght;
            }
            if (_invicbilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }

        Die();

    }
    public void HurtPlayer(int damage, Vector3 direction)
    {
        
        if (_invicbilityCounter <= 0)
        {
            _currentLife -= damage;
            _lifePanelList[_lifeLose].ShowDamage();
            _lifeLose++;
         
            if (_currentLife <= 0)
            {
                
            }
            else
            {
                thePlayer.KnocBack(direction);
                _invicbilityCounter = invincibilityLenght;
                playerRenderer.enabled = false;
                _flashcounter = flashLenght;
            }
          
        }
       
    }
   
  
   
   
    public void HealPlayer(int heal)
    {
        
        _currentLife += heal;
        
        _lifePanelList[_lifeLose - heal].ResetColor();
        _lifeLose--;
        
        
       
        
        

        if (_currentLife > maxLife)
        {
            _currentLife = maxLife;
        }
    }
    public void Die()
    {
        if (_currentLife == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    
    
    
  
  
    


   
   
  
}
