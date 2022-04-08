namespace GestorProyectos.Infrastructure.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        string UnHash(string decriptText);
        bool Check(string hash, string password);
    }
}