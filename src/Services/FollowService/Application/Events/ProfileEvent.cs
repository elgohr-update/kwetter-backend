﻿using System;

namespace Kwetter.Services.FollowService.Application.Events
{
    public class ProfileEvent
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
    }
}