﻿using System.Collections.Generic;
using System.Linq.Expressions;

namespace Singularity.Graph.Interfaces
{
    public interface IDependencyExpressionGenerator
    {
        void Generate(UnresolvedDependency unresolvedDependency, ParameterExpression instanceParameter, List<ParameterExpression> parameters, List<Expression> body);
    }
}