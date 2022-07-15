using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private Slider HealthBar;
        [SerializeField]
        private GameObject LoseGameObject;
        [SerializeField] private float jumpForse = 1f;
        public Rigidbody2D rb;
        public int monets = 0;
        [SerializeField] private float health = 100;
        [SerializeField] private GameObject chunksPlacer;
        [SerializeField]
        private Text Monets;
        [SerializeField]
        private Text MonetsTwo;

        private void Start()
        {
            HealthBar.value = health;
        }


        void Update()
        {
            Run();
            Monets.text = " " + monets;
            MonetsTwo.text = " " + monets;

            HealthBar.value = health;
            if (health < 1)
            {
                chunksPlacer.GetComponent<ChunksPlacer>().SetActive(false);
                chunksPlacer.SetActive(false);
                LoseGameObject.SetActive(true);
                Destroy(gameObject);
            }
        }

        public void OnMouseDown()
        {
            rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);

        }

        private void Run()
        {
            Vector3 dir = transform.right * 10;

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed);
        }




        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "Monstr")
            {

                health -= 5;

            }
            else if (collision.gameObject.tag == "Monet")
            {
                monets += 5;
                collision.gameObject.SetActive(false);
            }

        }
    }
}
