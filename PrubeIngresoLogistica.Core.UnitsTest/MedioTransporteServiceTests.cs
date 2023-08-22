using Moq;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.UnitsTest
{
    public class MedioTransporteServiceTests
    {
        [Fact]
        public async Task AddExitoso()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var medioTransporteRepositoryMock = new Mock<IMedioTransporteRepository>();

            unitOfWorkMock.SetupGet(uow => uow.MedioTransporteRepository).Returns(medioTransporteRepositoryMock.Object);

            var medioTransporteService = new MedioTransporteService(unitOfWorkMock.Object);
            var medioTransporte = new MedioTransporte();

            // Act
            var result = await medioTransporteService.Add(medioTransporte);

            // Assert
            medioTransporteRepositoryMock.Verify(repo => repo.Add(medioTransporte), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.Equal(medioTransporte, result);
        }

        [Fact]
        public async Task AddError()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var medioTransporteRepositoryMock = new Mock<IMedioTransporteRepository>();

            unitOfWorkMock.SetupGet(uow => uow.MedioTransporteRepository).Returns(medioTransporteRepositoryMock.Object);

            var medioTransporteService = new MedioTransporteService(unitOfWorkMock.Object);
            var medioTransporte = new MedioTransporte();

            // Act
            var result = await medioTransporteService.Add(medioTransporte);

            // Assert
            medioTransporteRepositoryMock.Verify(repo => repo.Add(medioTransporte), Times.Once);
            unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
            Assert.True(result.Id==0);
        }
    }
}
