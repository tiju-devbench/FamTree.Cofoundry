﻿using Cofoundry.Core.Mail;
using Cofoundry.Domain;
using Cofoundry.Domain.CQS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Domain.Members
{
    /// <summary>
    /// This command handler ties together a number of functions built
    /// into Cofoundry such as saving a new user, sending a notification
    /// and logging them in.
    /// </summary>
    public class RegisterMemberAndLogInCommandHandler
        : ICommandHandler<RegisterMemberAndLogInCommand>
        , IIgnorePermissionCheckHandler
    {
        private readonly IAdvancedContentRepository _contentRepository;

        private readonly ILoginService _loginService;
        private readonly IMailService _mailService;
        
        public RegisterMemberAndLogInCommandHandler(
            IAdvancedContentRepository contentRepository,
            ILoginService loginService,
            IMailService mailService
            )
        {
            _contentRepository = contentRepository;
            _loginService = loginService;
            _mailService = mailService;
        }

        public async Task ExecuteAsync(RegisterMemberAndLogInCommand command, IExecutionContext executionContext)
        {
            var roleId = await GetMemberRoleId();
            var addUserCommand = MapAddUserCommand(command, roleId);
            
            // Because we're not logged in, we'll need to elevate permissions to add a new user account.
            await _contentRepository
                .WithElevatedPermissions()
                .Users()
                .AddAsync(addUserCommand);

            //await SendWelcomeNotification(command);

            // Log the user in. Note that the new user id is set in the OutputUserId which is a 
            // convention used by the CQS framework (see https://www.cofoundry.org/docs/framework/cqs)
            await _loginService.LogAuthenticatedUserInAsync(addUserCommand.UserAreaCode, addUserCommand.OutputUserId, true);
        }

        /// <summary>
        /// Every user needs to be assigned a role. We've created a MemberRole in 
        /// code, so we can use our code definition to find out the database id which 
        /// we need to create the new user
        /// </summary>
        private async Task<int> GetMemberRoleId()
        {
            var role = await _contentRepository
                .Roles()
                .GetByCode(MemberRole.MemberRoleCode)
                .AsDetails()
                .ExecuteAsync();

            return role.RoleId;
        }

        /// <summary>
        /// We're going to make use of the built in AddUserCommand which will take 
        /// care of most of the logic for us. Here we map from our domain command to 
        /// the Cofoundry one. 
        /// 
        /// It's important that we don't expose the AddUserCommand directly in our
        /// web api, which could allow a 'parameter injection attack' to take place:
        /// 
        /// See https://www.owasp.org/index.php/Web_Parameter_Tampering
        /// </summary>
        private AddUserCommand MapAddUserCommand(RegisterMemberAndLogInCommand command, int roleId)
        {
            var addUserCommand = new AddUserCommand();
            addUserCommand.Email = command.Email;
            addUserCommand.FirstName = command.FirstName;
            addUserCommand.LastName = command.LastName;
            addUserCommand.Password = command.Password;
            addUserCommand.RoleId = roleId;
            addUserCommand.UserAreaCode = MemberUserArea.MemberUserAreaCode;

            return addUserCommand;
        }

        /// <summary>
        /// For more info on sending mail with Cofoundry see https://www.cofoundry.org/docs/framework/mail
        /// </summary>
        private async Task SendWelcomeNotification(RegisterMemberAndLogInCommand command)
        {
            //var welcomeEmailTemplate = new NewUserWelcomeMailTemplate();
            //welcomeEmailTemplate.FirstName = command.FirstName;
            //await _mailService.SendAsync(command.Email, welcomeEmailTemplate);
        }
    }
}
