using JobHub.Api.Controllers;
using JobHub.Application.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JobHub.Tests
{
    public class CandidateTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<CandidateController>> _loggerMock;
        public CandidateTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<CandidateController>>();
        }
        [Fact]
        public async void AddCandidatedSuccessfully_Return_CreatedResult()
        {
            //arrange

            SaveProfileCommand command = new SaveProfileCommand()
            {
                Id = "3",
                Email = "Omarsalahit2016@gmail.com",
                FirstName = "Omar",
                LastName = "Salah",

            };
            _mediatorMock.Setup(x => x.Send(command, default(CancellationToken))).Returns(Task.FromResult(true));
            var candidateController = new CandidateController(_mediatorMock.Object, _loggerMock.Object);

            //act
            var productResult = candidateController.Save(command).Result;

            //assert
            Assert.IsType<CreatedResult>(productResult);

        }
        [Fact]
        public async void AddCandidatedWithInvlidData_Return_BadResult()
        {
            //arrange

            SaveProfileCommand command = new SaveProfileCommand()
            {

                Email = "Omarsalahit2016@gmail.com",
                FirstName = "Omar",
                LastName = "Salah",

            };
            _mediatorMock.Setup(x => x.Send(command, default(CancellationToken))).Returns(Task.FromResult(false));
            var candidateController = new CandidateController(_mediatorMock.Object, _loggerMock.Object);

            //act
            var productResult = candidateController.Save(command).Result;

            //assert
            Assert.IsType<BadRequestObjectResult>(productResult);

        }

    }
}
