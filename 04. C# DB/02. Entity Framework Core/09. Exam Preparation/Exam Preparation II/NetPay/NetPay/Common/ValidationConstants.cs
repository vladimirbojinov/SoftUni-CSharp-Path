namespace NetPay.Common;

public static class ValidationConstants
{
    // Service START
    public const int ServiceNameMaxLength = 30;
    public const int ServiceNameMinLength = 5;
    // Service END

    // Supplier START
    public const int SupplierNameMaxLength = 60;
    public const int SupplierNameMinLength = 3;
    // Supplier END

    //Household START
    public const int HouseholdContactPersonMaxLength = 50;
    public const int HouseholdContactPersonMinLength = 5;
    public const int HouseholdEmailMaxLength = 80;
    public const int HouseholdEmailMinLength = 6;
    public const int HouseholdPhoneNumberLength = 15;
    public const string HouseholdPhoneNumberPattern = @"^\+\d{3}/\d{3}-\d{6}$";
    //Household END

    //Expense START
    public const int ExpenseNameMaxLength = 50;
    public const int ExpenseNameMinLength = 5;
    //Expense END
}
