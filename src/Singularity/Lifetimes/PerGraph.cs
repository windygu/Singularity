﻿using System;
using Singularity.Expressions;

namespace Singularity
{
    /// <summary>
    /// The same instance will be used in the entire graph
    /// Not implemented
    /// </summary>
    internal sealed class PerGraph : ILifetime
    {
        /// <inheritdoc />
        public void ApplyLifetimeOnExpression(Scoped containerScope, ExpressionContext context)
        {
            throw new NotImplementedException(nameof(PerGraph));
        }

        internal PerGraph() { }
    }
}