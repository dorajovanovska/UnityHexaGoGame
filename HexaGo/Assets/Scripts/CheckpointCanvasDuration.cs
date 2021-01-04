using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointCanvasDuration : MonoBehaviour
{
    private float CurrentTime = 0.0f;
    readonly private float StartingTime = 2.5f;

    public GameObject _checkpointObject;
    public Text _checkPointText;
    public GameObject _checkpointCanvas;

    private bool _IsCollision = false;

    public void Start()
    {
        CurrentTime = StartingTime;
        this.enabled = true;
    }

    public void Update()
    {
        _checkpointCanvas.gameObject.SetActive(false);

        if (_IsCollision == true)
        {
            _checkpointCanvas.gameObject.SetActive(true);
            _checkPointText.text = "Checkpoint saved!";
            CurrentTime -= 1 * Time.deltaTime;

            if (CurrentTime < 0)
            {
                _checkpointCanvas.gameObject.SetActive(false);
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            _IsCollision = true;
        }
    }
}
