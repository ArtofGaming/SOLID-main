using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{

    private IRayProvider _rayProvider;
    private ISelector _selector;
    private ISelectionResponse _selectionResponse;

    private Transform _currentSelection;

    private void Awake()
    {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update()
    {
        //deselection/selection response
        if (_currentSelection != null)
        {
            _selectionResponse.OnDeselect(_currentSelection);
        }

        //creating a ray

        //selection determination
        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();



        //deselection / selection response
        if (_currentSelection != null)
        {
            _selectionResponse.OnSelect(_currentSelection);
        }
    }

}
