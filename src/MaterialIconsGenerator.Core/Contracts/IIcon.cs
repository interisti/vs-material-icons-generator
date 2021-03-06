﻿using System.Collections.Generic;

namespace MaterialIconsGenerator.Core
{
    public interface IIcon
    {
        string Id { get;}

        string Name { get; }

        IIconCategory Category { get; }

        IEnumerable<string> Keywords { get; }

        string PreviewUrl { get; }

        IIconProvider Provider { get; }
    }
}
