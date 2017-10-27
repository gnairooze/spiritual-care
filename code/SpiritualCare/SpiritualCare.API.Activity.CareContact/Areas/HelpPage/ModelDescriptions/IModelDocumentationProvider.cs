using System;
using System.Reflection;

namespace SpiritualCare.API.Activity.CareContact.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}