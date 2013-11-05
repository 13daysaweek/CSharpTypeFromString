using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThirteenDaysAWeek.TypeLoadFromString.Tests
{
    [TestClass]
    public class TypeLoadTests
    {
        [TestMethod]
        public void GetType_Should_Return_Null_For_FullName()
        {
            // Arrange
            Type theType = typeof(Domain<CustomerModel>);
            string fullName = theType.FullName;

            // Act
            // FullName will have the fully qualified name for any generic type parameters but *NOT* for the generic type itself.
            // This results in loadedType being null when we call Type.GetType because the type we're trying to load is in another
            // assembly.  By default, Type.GetType searches the current assembly and mscorlib only.  Since the generic type isn't
            // fully qualified, Type.GetType will return null.
            Type loadedType = Type.GetType(fullName);

            // Assert
            loadedType.Should()
                .BeNull();
        }

        [TestMethod]
        public void GetType_Should_Return_Type_Instance_For_AssemblyQualifiedName()
        {
            // Arrange
            Type theType = typeof (Domain<CustomerModel>);
            string assemblyQualifiedName = theType.AssemblyQualifiedName;

            // Act
            // AssemblyQualifiedName will have the fully qualified type name for both the generic type as well as any type parameters.
            // Since the generic type and it's parameter type are located in a separate assembly but are loaded using fully qualified
            // names, Type.GetType will return an instance of the specified type.
            Type loadedType = Type.GetType(assemblyQualifiedName);

            // Assert
            loadedType.Should()
                .NotBeNull();
        }
    }
}
