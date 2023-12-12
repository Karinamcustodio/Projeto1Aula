namespace RepresentanteMVC.Interfaces
{
    public interface ICrud<T>
    {
        bool Adicionar(T t);
        bool Editar(T t);
        void Deletar(int id);
        T ConsultarPorId(int id);
        List<T> ConsultarTodos();
    }
}
