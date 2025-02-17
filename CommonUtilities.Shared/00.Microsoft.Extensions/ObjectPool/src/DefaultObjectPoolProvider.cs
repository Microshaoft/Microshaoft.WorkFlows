﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microshaoft.Extensions.ObjectPool
{
    using System;
    public class DefaultObjectPoolProvider : ObjectPoolProvider
    {
        public int MaximumRetained { get; set; } = Environment.ProcessorCount * 2;

        public override ObjectPool<T> Create<T>(IPooledObjectPolicy<T> policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            if (typeof(IDisposable).IsAssignableFrom(typeof(T)))
            {
                return new DisposableObjectPool<T>(policy, MaximumRetained);
            }

            return new DefaultObjectPool<T>(policy, MaximumRetained);
        }
    }
}
