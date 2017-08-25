using System;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSProjectIcon : GoogleProjectIcon
    {
        public GoogleiOSProjectIcon(IIcon icon, IIconColor color, string size, string density)
            : base(icon, color, size, density)
        { }

        public override string FullName => throw new NotImplementedException();

        protected override string GenerateUrl()
        {
            throw new NotImplementedException();
        }
    }
}
