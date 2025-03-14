﻿using HabitFlow.SharedKernel;

namespace HabitFlow.Application.Abstractions.Identity;
public interface IIdentityProviderService
{
    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}
