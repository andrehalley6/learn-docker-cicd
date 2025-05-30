using LearnDockerCiCd.Application.DTO;
using LearnDockerCiCd.Application.Interfaces;
using LearnDockerCiCd.Application.Services;
using LearnDockerCiCd.Domain.Entities;
using LearnDockerCiCd.Infrastructure.Interfaces;
using Moq;

namespace LearnDockerCiCd.Tests.Services;

public class UserServiceTests
{
    private readonly IUserService _userService;
    private readonly Mock<IUserRepository> _userRepoMock;

    public UserServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepoMock.Object);
    }

    [Fact]
    public async Task GetAllUsersAsync_ReturnUserList()
    {
        // Arrange
        var users = new List<UserDto>()
        {
            new() { ID = 1, Name = "John Doe", Email = "john.doe@workmail.com" },
            new() { ID = 2, Name = "Jane Doe", Email = "jane.doe@workmail.com" },
        };

        _userRepoMock.Setup(repo => repo.GetAllUsersAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(users.Select(u => new User
            {
                ID = u.ID,
                Name = u.Name,
                Email = u.Email
            }));

        // Act
        var result = await _userService.GetAllUsersAsync(default);
        var resultList = result.ToList();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Equal("John Doe", resultList[0].Name);
    }

    [Fact]
    public async Task GetUserByIDAsync_UserExist()
    {
        // Arrange
        var user = new UserDto { ID = 1, Name = "John Doe", Email = "john.doe@workmail.com" };
        _userRepoMock.Setup(repo => repo.GetUserAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User
            {
                ID = user.ID,
                Name = user.Name,
                Email = user.Email
            });

        // Act
        var result = await _userService.GetUserAsync(1, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.ID, result?.ID);
        Assert.Equal(user.Name, result?.Name);
        Assert.Equal(user.Email, result?.Email);
    }

    [Fact]
    public async Task GetUserByIDAsync_UserNotExist()
    {
        // Arrange
        _userRepoMock.Setup(repo => repo.GetUserAsync(999, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        // Act
        var result = await _userService.GetUserAsync(999, default);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateUserAsync_ValidUser()
    {
        // Arrange
        var createUserDto = new CreateUserDto { Name = "John Doe", Email = "john.doe@workmail.com" };
        var user = new User { ID = 1, Name = createUserDto.Name, Email = createUserDto.Email };
        _userRepoMock.Setup(repo => repo.CreateUserAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        // Act
        var result = await _userService.CreateUserAsync(createUserDto, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(0, result?.ID);
        Assert.Equal(user.Name, result?.Name);
        Assert.Equal(user.Email, result?.Email);
    }
}