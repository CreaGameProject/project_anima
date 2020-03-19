using UnityEngine;

namespace Assets.Scripts.Prey
{
    /// <summary>
    /// 穢物の部位のコンポーネント
    /// </summary>
    public class Part : MonoBehaviour, IDamageable
    {
        [SerializeField] private string name;
        [SerializeField] private int health;

        private Prey prey;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
        }

        public bool Damage(int attack)
        {
            health -= attack;
            if (health <= 0)
            {
                Break();
            }

            return true;
        }

        private void Break()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bullet")
            {
                Damage(50);
                prey.Damage(50);
            }
        }

        private void Start()
        {
            prey = GetComponentInParent<Prey>();
        }
    }
    
}
