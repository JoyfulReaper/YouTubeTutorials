using ErrorOr;

namespace BuberBreakfast.ServiceErrors;

public static class Errors {
    public static class Breakfast {
        public static Error NotFound => 
            Error.NotFound("Breakfast.NotFound", "Breakfast not found");

        public static Error InvalidName => 
            Error.Validation("Breakfast.InvalidName", $"Breakfast name must be at {Models.Breakfast.MinNameLength} to {Models.Breakfast.MaxNameLength} characters long");

        public static Error InvalidDescription => 
            Error.Validation("Breakfast.InvalidDescription", $"Breakfast description must be at {Models.Breakfast.MinDescriptionLength} to {Models.Breakfast.MaxDescriptionLength} characters long");
    }
}