// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MQTTnet.Server
{
    using System.Collections;
    using System.Collections.Generic;

    // Patch to enable restoring sessions from external source
    public class SessionData
    {
        public string ClientId { get; set; }
        public IDictionary Items { get; set; }
        public IEnumerable<string> Topics { get; set; }
    }
}