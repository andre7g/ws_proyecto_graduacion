namespace ws_proyecto.Interfaces
{
    public interface IAlimentosPorcion
    {
        object getByGruposAlimenticios(int  gruposAlimenticiosId);
        object getById(int Id);
    }
}
