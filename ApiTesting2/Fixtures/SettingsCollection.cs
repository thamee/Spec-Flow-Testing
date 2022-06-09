﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTesting2.Fixtures
{
    [CollectionDefinition("Settings collection")]
    public class SettingsCollection : ICollectionFixture<SettingsFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
        // READ MORE: https://xunit.net/docs/shared-context
    }
}
