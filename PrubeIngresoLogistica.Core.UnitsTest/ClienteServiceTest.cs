using Moq;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Core.Services;

namespace PrubeIngresoLogistica.Core.UnitsTest
{
    public class ClienteServiceTest
    {

        [Fact]
        public async Task AddExitoso()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var clienteRepositoryMock = new Mock<IClienteRepository>();

            unitOfWorkMock.SetupGet(uow => uow.ClienteRepository).Returns(clienteRepositoryMock.Object);

            var clienteService = new ClienteService(unitOfWorkMock.Object);
            var entity = new Cliente
            {
                Id = 1,
                Nombre = "Usuario"
            };

            // Act
            var result = await clienteService.Add(entity);

            // Assert
            clienteRepositoryMock.Verify(repo => repo.Add(entity), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task AddError()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var clienteRepositoryMock = new Mock<IClienteRepository>();

            unitOfWorkMock.SetupGet(uow => uow.ClienteRepository).Returns(clienteRepositoryMock.Object);

            var clienteService = new ClienteService(unitOfWorkMock.Object);
            var entity = new Cliente();

            // Act
            var result = await clienteService.Add(entity);

            // Assert
            clienteRepositoryMock.Verify(repo => repo.Add(entity), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.True(result.Id==0);
        }
    }





    
}
