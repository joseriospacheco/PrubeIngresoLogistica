namespace PrubeIngresoLogistica.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IClienteRepository ClienteRepository { get; }
        ILugarDestinoRepository LugarDestinoRepository { get; }
        IEntregaRepository EntregaRepository { get; }
        Task<int> SaveChangesAsync();

        IMedioTransporteRepository MedioTransporteRepository { get; }
    }
}
