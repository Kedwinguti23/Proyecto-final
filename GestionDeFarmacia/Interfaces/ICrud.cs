namespace GestionDeFarmacia.Interfaces
{
    //Este es un ejemplo de una interfaz genérica para operaciones CRUD (Crear, Leer, Actualizar, Eliminar)
    public interface ICrud<T>
    {
        void Crear(T entidad);          // Crea un nuevo registro
        void Listar();                  // Muestra todos los registros
        void Actualizar(int id, T nuevaEntidad);  // Actualiza un registro existente por ID
        void Eliminar(int id);          // Elimina un registro por ID
    }
}
