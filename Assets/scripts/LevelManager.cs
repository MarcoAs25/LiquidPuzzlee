using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public int nivelAtual, quantidadeDeNiveis = 2, nivelMaisAltoTerminado;
    internal static LevelManager inst;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        nivelAtual = PlayerPrefs.GetInt("nivelAtual3", 1);
        nivelMaisAltoTerminado = PlayerPrefs.GetInt("nivelMaisAltoTerminado3", 0);
    }

    public void ChangeNewLevel()
    {
        if(getNivelAtual() > getNivelMaisAltoTerminado())
        {
            nivelAtual++;
            nivelMaisAltoTerminado++;
            PlayerPrefs.SetInt("nivelMaisAltoTerminado3", nivelMaisAltoTerminado);
        }
        else
        {
            nivelAtual++;
        }
    }

    public int getQuantidadeDeNiveis() => quantidadeDeNiveis;
    public int getNivelAtual() => nivelAtual;
    public int getNivelMaisAltoTerminado() => nivelMaisAltoTerminado;
    public bool isLastLevel() => getNivelAtual() == getQuantidadeDeNiveis();

}
