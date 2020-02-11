using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pray
{
    public abstract class Pray : MonoBehaviour
    {
        private int health;
        readonly Dictionary<string, int> parts = new Dictionary<string, int>();

        protected void Damage(int attack, string part)
        {
            if (attack < 0) return;

            health = Mathf.Max(0, health - attack);
            if (parts.ContainsKey(part))
            {
                parts[part] = Mathf.Max(0, parts[part] - attack);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
