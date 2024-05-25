using AseProda.Domain.DTO.Surtidores;
using AseProda.Domain.Enums;
using AseProda.Domain.Interfaces;
using AseProda.Domain.Responses.Estados;
using AseProda.Domain.Services;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AseProda.Test
{
    public class AseProdaServiceTests
    {
        private ISurtidorService _surtidorService;
        private const decimal PrecioPrefijadoPorDefecto = 20.0M;

        [SetUp]
        public void Setup()
        {
            _surtidorService = new SurtidorService();
        }

        [Test]
        [Description("Test intended to check the correct behaviour of liberar surtidor logics.")]
        public async Task Liberar_Surtidor_Test()
        {
            // arrange
            Surtidor surtidor = new Surtidor();

            // act
            var response = await _surtidorService.LiberarSurtidorAsync(surtidor);

            // assert
            response.Should().NotBeNull();
            response.EstadoSurtidor.Should().Be(EstadosSurtidor.Libre);
        }

        [Test]
        [Description("Test intended to check the correct behaviour of bloquear surtidor logics.")]
        public async Task Bloquear_Surtidor_Test()
        {
            // arrange
            Surtidor surtidor = new Surtidor();

            // act
            var response = await _surtidorService.BloquearSurtidorAsync(surtidor);

            // assert
            response.Should().NotBeNull();
            response.EstadoSurtidor.Should().Be(EstadosSurtidor.Bloqueado);
            response.SuministroPrefijado.Should().Be(default);
        }

        [Test]
        [Description("Test intended to check the correct behaviour of prefijar precio del surtidor logics.")]
        public async Task Prefijar_Surtidor_Test()
        {
            // arrange
            Surtidor surtidor = new Surtidor();

            // act
            var response = await _surtidorService.PrefijarSurtidorAsync(surtidor);

            // assert
            response.Should().Be(PrecioPrefijadoPorDefecto);
        }

        [Test]
        [Description("Test intended to check the correct behaviour of prefijar precio del surtidor logics.")]
        public async Task Obtener_Estado_Surtidor_Test()
        {
            // arrange
            Surtidor surtidorTest1 = new Surtidor() { EstadoSurtidor = EstadosSurtidor.Libre };
            Surtidor surtidorTest2 = new Surtidor() { EstadoSurtidor = EstadosSurtidor.Bloqueado };
            IEnumerable<Surtidor> surtidores = new List<Surtidor>() { surtidorTest1, surtidorTest2 };

            // act
            var response = await _surtidorService.ObtenerEstadosSurtidoresAsync(surtidores);

            // assert
            response.Should().HaveCount(2);
            response.Should().BeEquivalentTo(new List<EstadoSurtidor>() { new EstadoSurtidor() { Estado = EstadosSurtidor.Libre } , new EstadoSurtidor() { Estado = EstadosSurtidor.Bloqueado } });
        }
    }
}