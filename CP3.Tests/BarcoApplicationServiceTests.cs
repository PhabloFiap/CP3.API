using CP3.Application.Services;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;
using Moq;

namespace CP3.Tests
{
    public class BarcoApplicationServiceTests
    {
        
        private readonly Mock<IBarcoRepository> _repositoryMock;
        private readonly BarcoApplicationService _BarcoService;
        

        public BarcoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IBarcoRepository>();
            _BarcoService = new BarcoApplicationService(_repositoryMock.Object);


        }

        [Fact]
        public void AdicionarBarco()
        {
            // Arrange
            var barcoDto = new Mock<IBarcoDto>();
            barcoDto.SetupGet(x => x.Nome).Returns("Barco 1");
            barcoDto.SetupGet(x => x.Modelo).Returns("Modelo 1");
            barcoDto.SetupGet(x => x.Ano).Returns(2021);
            barcoDto.SetupGet(x => x.Tamanho).Returns(10.5);

            var barcoEntity = new BarcoEntity
            {
                Nome = barcoDto.Object.Nome,
                Modelo = barcoDto.Object.Modelo,
                Ano = barcoDto.Object.Ano,
                Tamanho = barcoDto.Object.Tamanho
            };

            _repositoryMock.Setup(x => x.Adicionar(It.IsAny<BarcoEntity>())).Returns(barcoEntity);

            // Act
            var result = _BarcoService.AdicionarBarco(barcoDto.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(barcoEntity.Nome, result.Nome);
            Assert.Equal(barcoEntity.Modelo, result.Modelo);
            Assert.Equal(barcoEntity.Ano, result.Ano);
            Assert.Equal(barcoEntity.Tamanho, result.Tamanho);
        }
        [Fact]
        public void EditarBarco()
        {
            // Arrange
            var barcoDto = new Mock<IBarcoDto>();
            barcoDto.SetupGet(x => x.Nome).Returns("Barco 1");
            barcoDto.SetupGet(x => x.Modelo).Returns("Modelo 1");
            barcoDto.SetupGet(x => x.Ano).Returns(2021);
            barcoDto.SetupGet(x => x.Tamanho).Returns(10.5);

            var barcoEntity = new BarcoEntity
            {
                Nome = barcoDto.Object.Nome,
                Modelo = barcoDto.Object.Modelo,
                Ano = barcoDto.Object.Ano,
                Tamanho = barcoDto.Object.Tamanho
            };

            _repositoryMock.Setup(x => x.Editar(It.IsAny<BarcoEntity>())).Returns(barcoEntity);

            // Act
            var result = _BarcoService.EditarBarco(1, barcoDto.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(barcoEntity.Nome, result.Nome);
            Assert.Equal(barcoEntity.Modelo, result.Modelo);
            Assert.Equal(barcoEntity.Ano, result.Ano);
            Assert.Equal(barcoEntity.Tamanho, result.Tamanho);
        }
        [Fact]
        public void ObterBarcoPorId()
        {
            // Arrange
            var barcoEntity = new BarcoEntity
            {
                Nome = "Barco 1",
                Modelo = "Modelo 1",
                Ano = 2021,
                Tamanho = 10.5
            };

            _repositoryMock.Setup(x => x.ObterPorId(It.IsAny<int>())).Returns(barcoEntity);

            // Act
            var result = _BarcoService.ObterBarcoPorId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(barcoEntity.Nome, result.Nome);
            Assert.Equal(barcoEntity.Modelo, result.Modelo);
            Assert.Equal(barcoEntity.Ano, result.Ano);
            Assert.Equal(barcoEntity.Tamanho, result.Tamanho);
        }

        [Fact]
        public void ObterTodosBarcos()
        {
            // Arrange
            var barcoEntity = new BarcoEntity
            {
                Nome = "Barco 1",
                Modelo = "Modelo 1",
                Ano = 2021,
                Tamanho = 10.5
            };

            _repositoryMock.Setup(x => x.ObterTodos()).Returns(new List<BarcoEntity> { barcoEntity });

            // Act
            var result = _BarcoService.ObterTodosBarcos();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(barcoEntity.Nome, result.First().Nome);
            Assert.Equal(barcoEntity.Modelo, result.First().Modelo);
            Assert.Equal(barcoEntity.Ano, result.First().Ano);
            Assert.Equal(barcoEntity.Tamanho, result.First().Tamanho);
        }
        [Fact]
        public void RemoverBarco()
        {
            // Arrange
            var barcoEntity = new BarcoEntity
            {
                Nome = "Barco 1",
                Modelo = "Modelo 1",
                Ano = 2021,
                Tamanho = 10.5
            };

            _repositoryMock.Setup(x => x.Remover(It.IsAny<int>())).Returns(barcoEntity);

            // Act
            var result = _BarcoService.RemoverBarco(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(barcoEntity.Nome, result.Nome);
            Assert.Equal(barcoEntity.Modelo, result.Modelo);
            Assert.Equal(barcoEntity.Ano, result.Ano);
            Assert.Equal(barcoEntity.Tamanho, result.Tamanho);
        }


    }
}
