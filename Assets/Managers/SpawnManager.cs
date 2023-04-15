using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using static UnityEditor.Progress;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] Transform _spawnTransform;
    [SerializeField] GameObject _prefab;
    [SerializeField] Transform _planet;
    [SerializeField] Transform _enemySpawnPoint;

    [SerializeField] float _maxSpawnDistance = .3f;
    [SerializeField] float _villageSize = .3f;

    [SerializeField] int _timeToSpawn = 2;
    [SerializeField] int _nextTimeToSpawn;

    bool _canSpawn = true;

    private void Start()
    {
        DayAndNightCycleManager.instance.onHourPassed += SpawnEnemy;
        PlanetRotationEventHandler.instance.planetRotates += DisableManager;
        PlanetRotationEventHandler.instance.planetStopped += EnableManager;


    }

    void Update()
    {
        //if (Input.GetKeyDown("f"))
        //{
        //    //SpawnObject();
        //    SpawnEnemy();
        //}

    }


    //private void SpawnObject()
    //{
    //    float r = 2f;

    //    Vector3 _origin = _planet.position + Random.onUnitSphere * r;
    //    Vector3 randomPosition = _origin;



    //    //GameObject o = Instantiate(_prefab, randomPosition, Quaternion.identity);
    //    //o.transform.SetParent(_spawnTransform);


    //    //Vector3 _direction = Vector3.Normalize(_planet.position - o.transform.position);
    //    ////o.transform.rotation = Quaternion.LookRotation(_direction);


    //    //o.transform.rotation = Quaternion.FromToRotation(-transform.up, new Vector3(0, 0, 0)) * transform.rotation;

    //private void OnEnable()
    //{
    //    DayAndNightCycleManager.instance.onHourPassed += SpawnEnemy;
    //    PlanetRotationEventHandler.instance.planetRotates += DisableManager;
    //}

    //private void OnDisable()
    //{
    //    DayAndNightCycleManager.instance.onHourPassed -= SpawnEnemy;
    //    PlanetRotationEventHandler.instance.planetStopped += EnableManager;
    //}

    private void EnableManager()
    {
        _canSpawn = true;

        NavMeshAgent[] gameObjects = _spawnTransform.GetComponentsInChildren<NavMeshAgent>();
        foreach (var monster in gameObjects)
        {
            monster.enabled = true;
        }
    }

    private void DisableManager()
    {
        _canSpawn = false;

        NavMeshAgent[] gameObjects = _spawnTransform.GetComponentsInChildren<NavMeshAgent>();
        foreach (var monster in gameObjects)
        {
            monster.enabled = false;
        }
    }

    private void SpawnEnemy()
    {
        if (!_canSpawn)
        {
            return;
        }

        if (_nextTimeToSpawn == _timeToSpawn)
        {
            _nextTimeToSpawn = 0;
            _timeToSpawn = Random.Range(2, 4);

            float r = .3f;

            Vector3 _origin;
            Vector3 _findPosX;


            _origin = _planet.position + Random.onUnitSphere * r;


            _findPosX = new Vector3();

            Vector3 _nextEnemySpawnPoint = new Vector3(_origin.x, _enemySpawnPoint.position.y, _origin.z);

            Ray _terrainPoint = new Ray(_nextEnemySpawnPoint, new Vector3(0, -1, 0));
            RaycastHit _terrainHit;
            Physics.Raycast(_terrainPoint, out _terrainHit);


            GameObject spawnedobj = Instantiate(_prefab, new Vector3(_terrainHit.point.x, _terrainHit.point.y, _terrainHit.point.z), Quaternion.identity);
            spawnedobj.transform.SetParent(_spawnTransform);

            return;
        }

        _nextTimeToSpawn++;





        //float r = 1f;

        //Vector3 _origin;
        //Vector3 _findPosX;


        //_origin = _planet.position + Random.onUnitSphere * r;

        ////if (_origin.x < _planet.position.x + _villageSize || _origin.x < _planet.position.x - _villageSize)
        ////{
        ////    Debug.Log("keep looking!");
        ////    _findPosX = new Vector3(_origin.x, _enemySpawnPoint.position.y, _origin.z);
        ////    return;
        ////}



        ////while (_origin.x < _planet.position.x + _maxSpawnDistance || _origin.x < _planet.position.x - _maxSpawnDistance)
        ////{
        ////    _origin = _planet.position + Random.onUnitSphere * r;

        ////    if (_origin.z < _planet.position.z + _maxSpawnDistance || _origin.z < _planet.position.z - _maxSpawnDistance)
        ////    {
        ////        Debug.Log($"{_origin.ToString()}");
        ////        return;
        ////    }
        ////    //_origin.z < _planet.position.z + .3 || _origin.z < _planet.position.z - .3


        ////    //if (_origin.z < _planet.position.z + .3 || _origin.z < _planet.position.z - .3)
        ////    //{
        ////    //    Debug.Log($"origin {_origin.ToString()}");
        ////    //    return;
        ////    //}
        ////    ////|| _origin.z < _planet.position.z + .2
        ////    ////_origin = _planet.position + Random.onUnitSphere * r;
        ////    //Debug.Log($"origin {_origin.ToString()}");
        ////    //return;
        ////}

        ////GameObject o = Instantiate(_prefab, randomPosition, Quaternion.identity);
        ////o.transform.SetParent(_spawnTransform);


        ////Vector3 _direction = Vector3.Normalize(_planet.position - o.transform.position);
        //////o.transform.rotation = Quaternion.LookRotation(_direction);


        ////o.transform.rotation = Quaternion.FromToRotation(-transform.up, new Vector3(0, 0, 0)) * transform.rotation;



        //Vector3 _nextEnemySpawnPoint = new Vector3(_origin.x, _enemySpawnPoint.position.y, _origin.z);

        //Ray _terrainPoint = new Ray(_nextEnemySpawnPoint, new Vector3(0, -1, 0));
        //RaycastHit _terrainHit;
        //Physics.Raycast(_terrainPoint, out _terrainHit);


        //Instantiate(_prefab, new Vector3(_terrainHit.point.x, _terrainHit.point.y, _terrainHit.point.z), Quaternion.identity);


    }
}
