using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using FakeItEasy;
using FluentAssertions;
using FridgeProducts;
using FridgeProducts.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailService.Contracts;

namespace WebApiTests
{
    public class AuthorizationControllerTests
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;   
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly IEmailSender _emailSender;

        public AuthorizationControllerTests()
        {
            _repository = A.Fake<IRepositoryManager>();
            _mapper = A.Fake<IMapper>();
            _userManager = A.Fake<UserManager<User>>();
            _logger = A.Fake<ILoggerManager>();
            _authManager = A.Fake<IAuthenticationManager>();
            _emailSender = A.Fake<IEmailSender>();
        }

        [Fact]
        public void RegisterUser_WhenCalled_ReturnsStatusCode()
        {
            //Arrange
            var user = A.Fake<User>();
            var userForRegistration = A.Fake<UserForRegistrationDto>();
            var IdentityResult = A.Fake<IdentityResult>();
            var controller = new AuthorizationController(_logger, _mapper, _userManager, _repository, _authManager, _emailSender);
            A.CallTo(() => _mapper.Map<User>(userForRegistration)).Returns(user);
            A.CallTo(() => _userManager.CreateAsync(user, userForRegistration.Password)).Returns(IdentityResult).Equals(true);

            //Act
            var result = controller.RegisterUser(userForRegistration);
            A.CallTo(() => _userManager.AddToRolesAsync(user, userForRegistration.Roles)).MustHaveHappened();

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void Login_WhenCalled_ReturnsOk()
        {
            //Arrange
            var userForAuthentication = A.Fake<UserForAuthenticationDTO>();
            var controller = new AuthorizationController(_logger, _mapper, _userManager, _repository, _authManager, _emailSender);

            //Act
            var result = controller.Authenticate(userForAuthentication);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
