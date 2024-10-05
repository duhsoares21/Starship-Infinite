using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipCollision : MonoBehaviour
{
    public GameObject _meteorcollision;

    [SerializeField]
    private GameObject _shipcollision;

    [SerializeField]
    private GameObject _shipDestroy;

    [SerializeField]
    public GameObject ship;
    public bool gameover = false;

    private void Awake() {
        ship = GetComponent<Transform>().root.GetChild(0).gameObject;
        _shipcollision.GetComponent<ParticleSystem>().Stop();
        _shipDestroy.GetComponent<ParticleSystem>().Stop();
    }

    IEnumerator HapticFeedback(){
        Gamepad.current.SetMotorSpeeds(0.75f, 0.75f);
        yield return new WaitForSeconds(0.1f);
        Gamepad.current.SetMotorSpeeds(0, 0);
    }

    void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "enemy")
        {
            GameObject meteorCollision = Instantiate(_meteorcollision, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            meteorCollision.GetComponent<MeteorExplode>().OnObjectSpawn();

            _shipcollision.GetComponent<ParticleSystem>().Play();
            _shipcollision.GetComponent<AudioSource>().Play();

            Destroy(other.gameObject);
                
            float hp = ship.GetComponent<ShipStats>().getHp();

            hp -= other.gameObject.GetComponent<EnemyStats>().getDamage();
        
            ship.GetComponent<ShipStats>().setHp(hp);

            if(ship.GetComponent<ShipStats>().getHp() <= 0)
            {
                if(ship.name == "Player1_")
                {
                    GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetTimesDied();
                }

                if (GameObject.Find("Main Camera").GetComponent<GamePlayManager>().getLife() > 0)
                {
                   GameObject.Find("Main Camera").GetComponent<GamePlayManager>().setLife(GameObject.Find("Main Camera").GetComponent<GamePlayManager>().getLife() - 1);
                }
                
                _shipDestroy.GetComponent<ParticleSystem>().Play();
                _shipDestroy.GetComponent<AudioSource>().Play();

                if(GameObject.Find("Main Camera").GetComponent<GamePlayManager>().getLife() <= 0)
                {
                    if(!GameObject.Find("Main Camera").GetComponent<GamePlayManager>().gameover)
                    {
                        GameObject.Find("Main Camera").GetComponent<GamePlayManager>().gameover = true;
                        StartCoroutine("GameOver");
                    }
                }
                else
                {
                    ship.GetComponent<ShipStats>().setHp(100);
                    StartCoroutine("respawn");
                }
            }
        }
    }

    IEnumerator respawn(){
        ship.GetComponent<Player>().disablePlayerControls();
        ship.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        GameObject.Find("Shield").GetComponent<MeshRenderer>().enabled = true;
        GameObject.Find("Shield").GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(3f);
        ship.GetComponent<Player>().enablePlayerControls();
        GameObject.Find("Shield").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Shield").GetComponent<SphereCollider>().enabled = false;
    }

    IEnumerator GameOver(){
        GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetCurrentPointsP1(0);
        GameObject.Find("GameStats").GetComponent<GameStatsManager>().SetCurrentPointsP2(0);

        GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
        GameObject.Find("Player1_").GetComponent<Player>().disablePlayerControls();
        if(GameObject.Find("Player2_") != null)
        {
            GameObject.Find("Player2_").GetComponent<Player>().disablePlayerControls();
        }
        yield return new WaitForSeconds(3f);
        GameObject.Find("GameOver").GetComponent<Text>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<GameplayMusic>().SetMenuMusic();
        SceneManager.LoadSceneAsync("MainMenu");
    }
    
}
