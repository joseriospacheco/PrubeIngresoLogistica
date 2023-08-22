using Moq;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Enumerations;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.UnitsTest
{
    public class EntregaServiceTests
    {
        [Fact]
        public async Task AddExitoso()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var entregaRepositoryMock = new Mock<IEntregaRepository>();
            var lugarDestinoRepositoryMock = new Mock<ILugarDestinoRepository>();
            var clienteRepositoryMock = new Mock<IClienteRepository>();

            unitOfWorkMock.SetupGet(uow => uow.EntregaRepository).Returns(entregaRepositoryMock.Object);
            unitOfWorkMock.SetupGet(uow => uow.LugarDestinoRepository).Returns(lugarDestinoRepositoryMock.Object);
            unitOfWorkMock.SetupGet(uow => uow.ClienteRepository).Returns(clienteRepositoryMock.Object);

            var entregaService = new EntregaService(unitOfWorkMock.Object);

            var entidadEntrega = new Entrega
            {
                LugarDestinoId = 1,
                ClienteId = 2,
                CantidadPoducto = 3,
                ValorEnvio = 100
            };

            var lugarDestino = new LugarDestino { Tipo = TipoLugarDestino.PUERTO };
            var cliente = new Cliente();

            lugarDestinoRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(lugarDestino);
            clienteRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(cliente);

            // Act
            var result = await entregaService.Add(entidadEntrega);
            // Assert
            entregaRepositoryMock.Verify(repo => repo.Add(entidadEntrega), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);

            Assert.NotNull(result);

        }

    }
}
