namespace TravelAgency.Common;

public static class ValidationConstants
{
    //Customer START
    public const int CustomerFullNameMaxLength = 60;
    public const int CustomerFullNameMinLength = 4;
    public const int CustomerEmailMaxLength = 50;
    public const int CustomerEmailMinLength = 6;
    public const int CustomerPhoneNumberLength = 13;
    public const string CustomerPhoneNumberPattern = @"\+\d{12}";
    //Customer END

    //Guide START
    public const int GuideFullNameMaxLength = 60;
    public const int GuideFullNameMinLenght = 4;
    //Guide END

    //TourPackage START
    public const int TourPackageNameMaxLenght = 40;
    public const int TourPackageNameMinLenght = 2;
    public const int TourPackageDescriptionMaxLength = 200;
    //TourPackage END
}
