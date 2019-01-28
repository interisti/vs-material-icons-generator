using System.Drawing;

namespace MaterialIconsGenerator.Core
{
    public interface IIconColor
    {
        string Name { get; }

        Color Color { get; }

        bool IsEditable { get; }

        bool Edit(string hex);
    }
}
