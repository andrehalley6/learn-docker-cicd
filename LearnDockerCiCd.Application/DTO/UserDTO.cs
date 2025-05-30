using System;

namespace LearnDockerCiCd.Application.DTO;

public class UserDto
{
    public int ID { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}

public class CreateUserDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}