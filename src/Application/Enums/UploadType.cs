using System.ComponentModel;

namespace NowWhat.Application.Enums
{
    public enum UploadType : byte
    {
        [Description(@"Images\Notes")]
        Note,

        [Description(@"Images\ProfilePictures")]
        ProfilePicture,

        [Description(@"Documents")]
        Document
    }
}