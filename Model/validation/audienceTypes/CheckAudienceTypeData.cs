namespace Model.validation.audienceTypes;

internal class CheckAudienceTypeData : IDescriptionValidation, ITypeNameValidation
{
    public bool ValidateDescription(string description)
    {
        if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description)) return false; else return true;
    }
    public bool ValidateTypeName(string typeName)
    {
        if (string.IsNullOrEmpty(typeName) || string.IsNullOrWhiteSpace(typeName)) return false; else return true;
    }
}
