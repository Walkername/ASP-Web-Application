using System;
using System.ComponentModel.DataAnnotations;
using ASP_Web_Application.Areas.Identity.Pages.Account;
using Xunit;
using Xunit.Sdk;

namespace ASP_Web_Application.Tests
{
    public class RegisterTests
    {
        [Fact]
        public void FirstNameIsRequired()
        {
            var model = new RegisterModel.InputModel();
            var validationContext = new ValidationContext(model, null, null) { MemberName = "FirstName" };
            var validationResult = Validator.TryValidateProperty(model.FirstName, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { FirstName = "Julia" };
            validationResult = Validator.TryValidateProperty(model.FirstName, validationContext, null);
            Assert.True(validationResult, "FirstName is required");
        }

        [Fact]
        public void FirstNameLength()
        {
            var model = new RegisterModel.InputModel() { FirstName = "This first name is too long" };
            var validationContext = new ValidationContext(model, null, null) { MemberName = "FirstName" };
            var validationResult = Validator.TryValidateProperty(model.FirstName, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { FirstName = "Julia" };
            validationResult = Validator.TryValidateProperty(model.FirstName, validationContext, null);
            Assert.True(validationResult, "First Name must not exceed 20 characters");
        }

        [Fact]
        public void LastNameIsRequired()
        {
            var model = new RegisterModel.InputModel();
            var validationContext = new ValidationContext(model, null, null) { MemberName = "LastName" };
            var validationResult = Validator.TryValidateProperty(model.LastName, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { LastName = "Walker" };
            validationResult = Validator.TryValidateProperty(model.LastName, validationContext, null);
            Assert.True(validationResult, "LastName is required");
        }

        [Fact]
        public void LastNameLength()
        {
            var model = new RegisterModel.InputModel() { LastName = "This first name is too long" };
            var validationContext = new ValidationContext(model, null, null) { MemberName = "LastName" };
            var validationResult = Validator.TryValidateProperty(model.LastName, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { LastName = "Walker" };
            validationResult = Validator.TryValidateProperty(model.LastName, validationContext, null);
            Assert.True(validationResult, "Last Name must not exceed 20 characters");
        }

        [Fact]
        public void AgeMinimum()
        {
            var model = new RegisterModel.InputModel() { Age = 12 };
            var validationContext = new ValidationContext(model, null, null) { MemberName = "Age" };
            var validationResult = Validator.TryValidateProperty(model.Age, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { Age = 18 };
            validationContext = new ValidationContext(model, null, null) { MemberName = "Age" };
            validationResult = Validator.TryValidateProperty(model.Age, validationContext, null);
            Assert.True(validationResult, "Age must be greater than 14 years");
        }

        [Fact]
        public void EmailIsRequired()
        {
            var model = new RegisterModel.InputModel();
            var validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            var validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { Email = "walker@gmail.com" };
            validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.True(validationResult, "Email is required");
        }

        [Fact]
        public void EmailValidation()
        {
            var model = new RegisterModel.InputModel() { Email = "ya@ya.ru" };
            var validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            var validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.True(validationResult, "Email must be a valid email address");

            model = new RegisterModel.InputModel() { Email = "It is not email address" };
            validationContext = new ValidationContext(model, null, null) { MemberName = "Email" };
            validationResult = Validator.TryValidateProperty(model.Email, validationContext, null);
            Assert.False(validationResult);
        }

        [Fact]
        public void PasswordIsRequired()
        {
            var model = new RegisterModel.InputModel();
            var validationContext = new ValidationContext(model, null, null) { MemberName = "Password" };
            var validationResult = Validator.TryValidateProperty(model.Password, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { Password = "Password123."};
            validationContext = new ValidationContext(model, null, null) { MemberName = "Password" };
            validationResult = Validator.TryValidateProperty(model.Password, validationContext, null);
            Assert.True(validationResult, "Password is required");
        }

        [Fact]
        public void ConfirmPasswordMatchesPassword()
        {
            var model = new RegisterModel.InputModel() { Password = "Password123.", ConfirmPassword = "Password1" };
            var validationContext = new ValidationContext(model, null, null) { MemberName = "ConfirmPassword" };
            var validationResult = Validator.TryValidateProperty(model.ConfirmPassword, validationContext, null);
            Assert.False(validationResult);

            model = new RegisterModel.InputModel() { Password = "Password123.", ConfirmPassword = "Password123." };
            validationContext = new ValidationContext(model, null, null) { MemberName = "ConfirmPassword" };
            validationResult = Validator.TryValidateProperty(model.ConfirmPassword, validationContext, null);
            Assert.True(validationResult, "ConfirmPassword must match Password");
        }
    }
}
