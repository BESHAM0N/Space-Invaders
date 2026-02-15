using System.Collections.Generic;
using UnityEngine;

namespace Game.Pool
{ 
    public class EntityPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _container;
        [SerializeField] private int _initialSize = 8;
        private readonly Queue<T> _pool = new();

        private void Awake()
        {
            GeneratePool(_initialSize);
        }

        private void GeneratePool(int poolSize)
        {
            for (var i = 0; i < poolSize; i++)
            {
                _pool.Enqueue(CreateNewEntity());
            }
        }

        public T GetEntity()
        {
            var obj =_pool.Count > 0 ? _pool.Dequeue() : CreateNewEntity();
            OnGetEntity(obj);
            return obj;
        }

        protected virtual void OnGetEntity(T obj)
        {
        
        }

        private T CreateNewEntity()
        {
            var newObject = Instantiate(_prefab, _container);
            newObject.gameObject.SetActive(true);
            return newObject;
        }

        public void ReturnEntity(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_container);
            _pool.Enqueue(obj);
        }
    }
}