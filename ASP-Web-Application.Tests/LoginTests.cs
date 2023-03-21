using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASP_Web_Application.Areas.Identity.Pages.Account;
using Xunit;

namespace ASP_Web_Application.Tests
{
    public class LoginTests
    {
        [Fact]
        public void EmailIsRequired()
        {
            var model = new LoginModel.InputModel();
            var validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            var validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.False(validationResult);

            model = new LoginModel.InputModel() { Email = "walker@gmail.com" };
            validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.True(validationResult, "Email is required");
        }

        [Fact]
        public void EmailValidation()
        {
            var model = new LoginModel.InputModel() { Email = "ya@ya.ru" };
            var validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            var validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.True(validationResult, "Email must be a valid email address");

            model = new LoginModel.InputModel() { Email = "It is not email address" };
            validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.False(validationResult);
        }

        [Fact]
        public void PasswordIsRequired()
        {
            var model = new LoginModel.InputModel();
            var validationContext = new ValidationContext(model, null, null) { MemberName = "Password" };
            var validationResult = Validator.TryValidateProperty(model.Password, validationContext, null);
            Assert.False(validationResult);

            model = new LoginModel.InputModel() { Password = "Password123." };
            validationContext = new ValidationContext(model, null, null) { MemberName = "Password" };
            validationResult = Validator.TryValidateProperty(model.Password, validationContext, null);
            Assert.True(validationResult, "Password is required");
        }
    }
}
