using TestingApp.Functionality;
using Xunit;
using System.Linq;

namespace TestingApp.Test
{
    public class UserManagementTesting
    {
        
        [Fact]
        public void Add_CreateUser()
        {
            // Given - Arrange
            var userManagement = new UserManagement();

            // When - Act 
            userManagement.Add(new("Mohamad", "Lawand"));

            // Then - Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser); //checking that the usermanagement list is not empty
            Assert.Equal("Mohamad", savedUser.firstName);
            Assert.Equal("Lawand", savedUser.lastName);
            Assert.False(savedUser.VerifiedEmail);
        }
        
        [Fact]
        public void Update_UpdateMobileNumber()
        {
            // Given - Arrange
            var userManagement = new UserManagement();

            // When - Act 
            userManagement.Add(new("Mohamad", "Lawand"));

            var firstUser = userManagement.AllUsers.First();
            firstUser.Phone = "+4400000032";

            userManagement.UpdatePhone(firstUser);
            
            // Then - Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("+4400000032", savedUser.Phone);
        }
    }
}