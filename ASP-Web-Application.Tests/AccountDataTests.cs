using ASP_Web_Application.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ASP_Web_Application.Tests
{
    public class AccountDataTests
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AccountDataTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDB");
            _context = new ApplicationDbContext(optionsBuilder.Options);

            _userManager = new UserManager<AppUser>(
                new UserStore<AppUser>(_context),
                null,
                new PasswordHasher<AppUser>(),
                new List<UserValidator<AppUser>>(),
                new List<PasswordValidator<AppUser>>(),
                new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(),
                new ServiceCollection().BuildServiceProvider(),
                null
                );
        }

        [Fact]
        public async Task CreateUser()
        {
            var user = new AppUser()
            {
                FirstName = "Elon",
                LastName = "Musk",
                Age = 51,
                Email = "elonmusk@gmail.com",
                PhoneNumber = "89215406578"
            };

            var result = await _userManager.CreateAsync(user, "Test123.");
            Assert.True(result.Succeeded);

            var newUser = await _userManager.FindByIdAsync(user.Id);

            Assert.Equal(user.FirstName, newUser.FirstName);
            Assert.Equal(user.LastName, newUser.LastName);
            Assert.Equal(user.Age, newUser.Age);
            Assert.Equal(user.Email, newUser.Email);
            Assert.Equal(user.PhoneNumber, newUser.PhoneNumber);
        }

        [Fact]
        public async Task UpdateUser()
        {
            var user = new AppUser()
            {
                FirstName = "Bill",
                LastName = "Gates",
                Age = 67,
                Email = "billgates@gmail.com",
                PhoneNumber = "83272406348"
            };

            var result = await _userManager.CreateAsync(user, "Bill123.");
            Assert.True(result.Succeeded);

            user = new AppUser()
            {
                FirstName = "Ben",
                LastName = "Walker",
                Age = 22,
                Email = "benwalker@yandex.ru",
                PhoneNumber = "83272406348"
            };

            result = await _userManager.UpdateAsync(user);

            var newUser = await _userManager.FindByIdAsync(user.Id);
            Assert.NotNull(newUser);

            Assert.Equal(user.FirstName, newUser.FirstName);
            Assert.Equal(user.LastName, newUser.LastName);
            Assert.Equal(user.Age, newUser.Age);
            Assert.Equal(user.Email, newUser.Email);
            Assert.Equal(user.PhoneNumber, newUser.PhoneNumber);
        }

        [Fact]
        public async Task DeleteUser()
        {
            var user = new AppUser()
            {
                FirstName = "Bill",
                LastName = "Gates",
                Age = 67,
                Email = "billgates@gmail.com",
                PhoneNumber = "83272406348"
            };

            var result = await _userManager.CreateAsync(user, "Bill123.");
            Assert.True(result.Succeeded);

            result = await _userManager.DeleteAsync(user);
            Assert.True(result.Succeeded);

            var newUser = await _userManager.FindByIdAsync(user.Id);
            Assert.Null(newUser);
        }
    }
}
