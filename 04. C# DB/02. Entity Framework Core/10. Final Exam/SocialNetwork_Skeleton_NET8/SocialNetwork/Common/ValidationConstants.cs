namespace SocialNetwork.Common;

public static class ValidationConstants
{
    //User START
    public const int UserUsernameMaxLength = 20;
    public const int UserUsernameMinLength = 4;
    public const int UserEmailMaxLength = 60;
    public const int UserEmailMinLength = 8;
    public const int UserPasswordMinLength = 6;
    //User END

    //Conversation START
    public const int ConversationTitleMaxLength = 30;
    public const int ConversationTitleMinLength = 2;
    //Conversation END

    //Post START
    public const int PostContentMaxLength = 300;
    public const int PostContentMinLength = 5;
    //Post END

    //Message START
    public const int MessageContentMaxLength = 200;
    public const int MessageContentMinLength = 1;
    //Message END
}
