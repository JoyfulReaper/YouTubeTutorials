
using BuberDinner.Domain.AggregateUser;

namespace BuberDinner.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);