using LogicalFitness.Application.Abstractions;
using MediatR;

namespace LogicalFitness.Application.Commands.Users;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
{
  private readonly IAppDbContext _db;
  private readonly IUserService _userService;
  public AddUserCommandHandler(
    IAppDbContext db,
    IUserService userService
  )
  {
    _db = db;
    _userService = userService;
  }
  public async Task<Guid> Handle(
    AddUserCommand request,
    CancellationToken cancellationToken
  )
  {
    var emailExists = await _userService.EmailExistsAsync(request.Email, cancellationToken);

    if (emailExists)
    {
      throw new InvalidOperationException("Email address already in use.");
    }

    var newUser = await _userService.CreateUser(
      request
    );

    _db.Users.Add(newUser);
    await _db.SaveChangesAsync(cancellationToken);

    return newUser.Id;
  }
}
