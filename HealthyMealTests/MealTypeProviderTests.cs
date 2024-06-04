using HealthyMeal.Utils;

namespace HealthyMealTests
{
    public class MealTypeProviderTests
    {
        [Theory]
        [InlineData("�������", MealType.Breakfast)]
        [InlineData("����", MealType.Lunch)]
        [InlineData("����", MealType.Dinner)]
        [InlineData("�������", MealType.Snack)]
        public void Provide_PassCorrectName_GetExpectedMealType_Test(string mealTypeName, MealType expectedMealType)
        {
            // Arrange:
            MealTypesProvider.RegisterAll();

            // Act:
            MealType actualMealType = MealTypesProvider.Provide(mealTypeName);

            // Assert:
            Assert.Equal(expectedMealType, actualMealType);
        }

        [Theory]
        [InlineData("�������")]
        [InlineData("��_����_���")]
        [InlineData("")]
        public void Provide_PassIncorrectName_CatchKeyNotFoundException(string mealTypeName)
        {
            // Arrange:
            MealTypesProvider.RegisterAll();

            // Act:
            Exception exception = Record.Exception(() => MealTypesProvider.Provide(mealTypeName));

            // Assert:
            Assert.IsType<KeyNotFoundException>(exception);
        }
    }
}