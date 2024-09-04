﻿
using Domain.SeedWork;
using Domain.SharedKernel;
using Domain.Aggregates.Users.ValueObjects;

namespace Domain.Aggregates.Users
{
    public class User : AggregateRoot
    {

        public MobileNumber MobileNumber { get; private set; }
        public ActivationCode ActivationCode { get; private set; }
        public HashedPassword HashedPassword { get; private set; }
        public ExpireTimeActivationCode ExpireTimeActivationCode { get; private set; }
    }
}
