using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirteenDaysAWeek.TypeLoadFromString.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetType_Should_Return_Type_Instance_For_AssemblyQualifiedName()
        {
            // Arrange
            Type theType = typeof (Domain<CustomerModel>);
            string assemblyQualifiedName = theType.AssemblyQualifiedName;

            // Act
            Type loadedType = Type.GetType(assemblyQualifiedName);

            // Assert
            loadedType.Should()
                .NotBeNull();
        }

        [TestMethod]
        public void GetType_Should_Return_Null_For_FullName()
        {
            // Arrange
            Type theType = typeof (Domain<CustomerModel>);
            string fullName = theType.FullName;

            // Act
            Type loadedType = Type.GetType(fullName);

            // Assert
            loadedType.Should()
                .BeNull();
        }
    }
}
