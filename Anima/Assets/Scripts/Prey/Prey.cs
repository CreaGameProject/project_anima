using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Prey
{
    public abstract class Prey : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health;
        [SerializeField] private float speed;
        public Dictionary<string, Part> Parts { get; private set; }

        private NavMeshAgent navAgent;
        private Animator animator;
        private AnimatorController animatorController;

        public virtual void MoveStart(Vector3 destination, float intensity)
        {
            if (navAgent.SetDestination(destination))
            {
                foreach (var pathCorner in navAgent.path.corners)
                {
                    Debug.Log(pathCorner);
                }
                navAgent.speed = speed * intensity;
                StartCoroutine(WalkMotion(intensity));
            }
        }

        private IEnumerator WalkMotion(float intensity)
        {
            Debug.Log(navAgent.nextPosition);
            animator.SetFloat("Intensity", intensity);
            animator.SetBool("Walking", true);
            while (navAgent.pathPending)
            {
                yield return null;
            }
            animator.SetBool("Walking", false);
            Debug.Log("Complete");
        }

        public bool Damage(int attack)
        {
            health -= attack;
            if (health <= 0)
            {
                Death();
            }
            return true;
        }

        private void Death()
        {

        }

        // Start is called before the first frame update
        void Awake()
        {
            Parts = GetComponentsInChildren<Part>().ToDictionary(x => x.Name);
            navAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name + ":collision");
            if (other.tag == "Bullet")
            {
                Damage(50);
            }
        }
    }
}
