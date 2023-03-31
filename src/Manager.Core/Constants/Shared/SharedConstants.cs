namespace Manager.Core.Shared
{
    public class SharedConstants
    {
        public const string RegexValidateEmail = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string FieldMinLength = "This field has not reached the minimum number of characters.";
        public const string FieldMaxLength = "This field exceeded the limit of characteres.";
        public const string FieldRequired = "This field is required.";
        public const string FieldNotValid = "This field is not valid.";
        public const string EntityNotEmpty = "This entity cannot be empty.";
        public const string EntityNotNull = "This entity cannot be null.";
        public const string FailedValidateEntity = "Failed on validate entity.";
        public const string FailedOnSaveEntity = "Failed on save entity.";
        public const string FailedOnUpdateEntity = "Failed on update entity.";
        public const string FailedOnRemoveEntity = "Failed on remove entity.";
        public const string FailedOnGetEntities = "Failed on get entities.";
        public const string FailedOnGetEntityById = "Failed on get entity by Id.";
        public const string FailedOnGetEntity = "Failed on get entity.";
        public const string SuccessOnSaveEntity = "Success on save entity.";
        public const string SuccessOnUpdateEntity = "Success on update entity.";
        public const string SuccessOnRemoveEntity = "Success on remove entity.";
        public const string ConnectionString = @"Server=.;Database=ManagerDB;Trusted_Connection=True;";
    }
}