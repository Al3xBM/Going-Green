using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UserService.Entities;
using UserService.Helpers;
using UserService.Models.Users;
using UserService.Services;
using UserService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using System.Collections.Generic;

namespace UserService.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        public Mock<IUserService> _userServiceMoq;
        public Mock<IMapper> _mapperMoq;
        public IOptions<AppSettings> _appSettings;
        public User user;
        public RegisterModel registerModel;
        public UpdateModel updateModel;
        
        [TestInitialize]
        public void SetUp()
        {
            _userServiceMoq = new Mock<IUserService>();
            _mapperMoq = new Mock<IMapper>();

            _appSettings = Options.Create(new AppSettings
            {
                Secret = "Hai la magazin"
            });


            user = new User
            {
                Id = 1,
                FirstName = "Ionut",
                LastName = "Tcaciuc",
                Email = "tcaciuc.ionut@gmail.com",
                PasswordHash = null,
                PasswordSalt = null
            };
            registerModel = new RegisterModel
            {
                FirstName = "Ionut",
                LastName = "Tcaciuc",
                Email = "tcaciuc.ionut@gmail.com",
                Password = "admin123"
            };
            updateModel = new UpdateModel
            {
                Email = "tcaciuc@gmal.com",
                Password = "admin1234"
              
            };

            _mapperMoq.Setup(moq => moq.Map<User>(registerModel)).Returns(user);

        }

        public List<User> UsersSeed()
        {
            var newSeed = new List<User>();
            newSeed.Add(new User
            {
                Id = 1,
                FirstName = "Ionut",
                LastName = "Tcaciuc",
                Email = "tcaciuc.ionut@gmail.com",
                PasswordHash = null,
                PasswordSalt = null
            });
            newSeed.Add(new User
            {
                Id = 2,
                FirstName = "Gabriel",
                LastName = "Tcaciuc",
                Email = "tcaciuc.Gabriel@gmail.com",
                PasswordHash = null,
                PasswordSalt = null
            });
            return newSeed;
        }

        [TestMethod]
        public void ReqisterReturnOK()
        { 
            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);
            
            IActionResult response = controller.Register(registerModel);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));

        }
        [TestMethod]
        public void ReqisterReturnExeption_When_PasswordIsEmpty()
        {
            _userServiceMoq.Setup(moq => moq.Create(user, "")).Throws(new  UserException(""));

            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);

            IActionResult response = controller.Register(registerModel); ;
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));

        }
        [TestMethod]
        public void AuthenticateReturnOK()
        {
            var model = new AuthenticateModel
            {
                Email = "tcaciuc.ionut@gmal.com",
                Password = "adimin123"
            };
          
            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);
           
            IActionResult response = controller.Authenticate(model); ;
            Assert.IsInstanceOfType(response, typeof(UnauthorizedObjectResult));

        }
        [TestMethod]
        public void UpdateReturnsNoContent()
        {
            _mapperMoq.Setup(moq => moq.Map<User>(updateModel)).Returns(user);

            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);

            IActionResult response = controller.Update(1,updateModel );
            Assert.IsInstanceOfType(response, typeof(NoContentResult));
        }
        [TestMethod]
        public void DeleteReturnsNoContent()
        {
            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);

            IActionResult response = controller.Delete(1); 
            Assert.IsInstanceOfType(response, typeof(NoContentResult));
        }
        [TestMethod] 
        public void GetByIdReturnsOk()
        {
            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);

            IActionResult response = controller.GetById(1);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
        [TestMethod]
        public void GetByIdReturnsCorrectUser()
        {
            var userModel = new UserModel
            { 
                FirstName = "ionut"
            };
            _userServiceMoq.Setup(moq => moq.GetById(1)).Returns(user);
            _mapperMoq.Setup(moq => moq.Map<UserModel>(user)).Returns(userModel);

            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);
            
            IActionResult response = controller.GetById(1);
            var res = response as OkObjectResult;
            Assert.IsNotNull(res);
       }
        [TestMethod]
        public void GetAllReturnsOk()
        {
            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);

            IActionResult response = controller.GetAll();
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
        [TestMethod]
        public void GetAllReturnsAllUsers()
        {
            _userServiceMoq.Setup(moq => moq.GetAll()).Returns(UsersSeed());

            var controller = new UsersController(_userServiceMoq.Object, _mapperMoq.Object, _appSettings);

            IActionResult response = controller.GetAll();
            var res = ((List<User>)((ObjectResult)response).Value);
            var expected =UsersSeed();
            CollectionAssert.Equals(res, expected);
        }
    }


 
}

