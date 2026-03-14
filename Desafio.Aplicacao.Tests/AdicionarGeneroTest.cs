using Desafio.Aplicacao.Generos.AdicionarGenero;
using Desafio.Comum;
using Desafio.Dominio.Generos;
using Moq;

namespace Desafio.Aplicacao.Tests
{
    public class AdicionarGeneroTest
    {
        private readonly Mock<IGeneroRepositorio> _generoRepositorioMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly AdicionarGeneroCommandHandler _handler;

        public AdicionarGeneroTest()
        {
            _generoRepositorioMock = new Mock<IGeneroRepositorio>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new AdicionarGeneroCommandHandler(
                _generoRepositorioMock.Object,
                _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task DeveAdicionarGeneroComSucesso_QuandoNomeEValido()
        {
            // Arrange
            var command = new AdicionarGeneroCommand("Ficção");
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsync(cancellationToken))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotEqual(Guid.Empty, result.Value);
            _generoRepositorioMock.Verify(
                x => x.Adicionar(It.IsAny<Genero>()),
                Times.Once);
            _unitOfWorkMock.Verify(
                x => x.SaveChangesAsync(cancellationToken),
                Times.Once);
        }

        [Fact]
        public async Task DeveRetornarIdValido_QuandoGeneroForAdicionado()
        {
            // Arrange
            var nomeGenero = "Romance";
            var command = new AdicionarGeneroCommand(nomeGenero);
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsync(cancellationToken))
                .ReturnsAsync(1);

            Genero? generoAdicionado = null;
            _generoRepositorioMock
                .Setup(x => x.Adicionar(It.IsAny<Genero>()))
                .Callback<Genero>(g => generoAdicionado = g);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            Assert.NotNull(generoAdicionado);
            Assert.Equal(nomeGenero, generoAdicionado.Nome);
            Assert.Equal(result.Value, generoAdicionado.Id);
        }

        [Fact]
        public async Task DeveChamarRepositorio_QuandoHandleForExecutado()
        {
            // Arrange
            var command = new AdicionarGeneroCommand("Drama");
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsync(cancellationToken))
                .ReturnsAsync(1);

            // Act
            await _handler.Handle(command, cancellationToken);

            // Assert
            _generoRepositorioMock.Verify(
                x => x.Adicionar(It.Is<Genero>(g => g.Nome == "Drama")),
                Times.Once);
        }

        [Fact]
        public async Task DeveSalvarAlteracoes_QuandoHandleForExecutado()
        {
            // Arrange
            var command = new AdicionarGeneroCommand("Aventura");
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsync(cancellationToken))
                .ReturnsAsync(1);

            // Act
            await _handler.Handle(command, cancellationToken);

            // Assert
            _unitOfWorkMock.Verify(
                x => x.SaveChangesAsync(cancellationToken),
                Times.Once);
        }

        [Fact]
        public async Task DeveGerarGuidUnico_ParaCadaGenero()
        {
            // Arrange
            var command = new AdicionarGeneroCommand("Terror");
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsync(cancellationToken))
                .ReturnsAsync(1);

            // Act
            var result1 = await _handler.Handle(command, cancellationToken);
            var result2 = await _handler.Handle(command, cancellationToken);

            // Assert
            Assert.NotEqual(result1.Value, result2.Value);
        }

        [Theory]
        [InlineData("Ação")]
        [InlineData("Comédia")]
        [InlineData("Drama")]
        [InlineData("Suspense")]
        [InlineData("Documentário")]
        public async Task DeveAdicionarDiferentesGeneros_ComSucesso(string nomeGenero)
        {
            // Arrange
            var command = new AdicionarGeneroCommand(nomeGenero);
            var cancellationToken = CancellationToken.None;

            _unitOfWorkMock
                .Setup(x => x.SaveChangesAsync(cancellationToken))
                .ReturnsAsync(1);

            Genero? generoAdicionado = null;
            _generoRepositorioMock
                .Setup(x => x.Adicionar(It.IsAny<Genero>()))
                .Callback<Genero>(g => generoAdicionado = g);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(nomeGenero, generoAdicionado?.Nome);
        }
    }
}
