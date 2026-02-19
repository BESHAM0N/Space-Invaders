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

                foreach (var entity in _pool)
                    entity.gameObject.SetActive(false);
            }
        }

        public T GetEntity()
        {
            var entity = _pool.Count > 0 ? _pool.Dequeue() : CreateNewEntity();
            entity.gameObject.SetActive(true);
            OnGetEntity(entity);
            return entity;
        }

        protected virtual void OnGetEntity(T obj)
        {
        }

        private T CreateNewEntity()
        {
            var newEntity = Instantiate(_prefab, _container);
            newEntity.gameObject.SetActive(true);
            OnCreate(newEntity);
            return newEntity;
        }

        protected virtual void OnCreate(T obj)
        {
        }

        public void ReturnEntity(T entity)
        {
            entity.transform.SetParent(_container);
            entity.gameObject.SetActive(false);
            _pool.Enqueue(entity);
        }
    }
}