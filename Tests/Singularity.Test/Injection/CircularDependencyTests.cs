﻿using Singularity.Exceptions;
using Singularity.TestClasses.TestClasses;
using Xunit;

namespace Singularity.Test.Injection
{
    public class CircularDependencyTests
    {
        [Fact]
        public void SimpleCircularDependency()
        {
            //ARRANGE
            var config = new BindingConfig();
            config.Register<ISimpleCircularDependency1, SimpleCircularDependency1>();
            config.Register<ISimpleCircularDependency2, SimpleCircularDependency2>();
            var container = new Container(config);

            //ACT
            //ASSERT
            var cycleError1 = Assert.Throws<CircularDependencyException>(() =>
            {
                var circularDependency = container.GetInstance<ISimpleCircularDependency1>();
            });
            Assert.Equal(3, cycleError1.Cycle.Count);
            Assert.Equal(typeof(SimpleCircularDependency1), cycleError1.Cycle[0]);
            Assert.Equal(typeof(SimpleCircularDependency2), cycleError1.Cycle[1]);
            Assert.Equal(typeof(SimpleCircularDependency1), cycleError1.Cycle[2]);

            var cycleError2 = Assert.Throws<CircularDependencyException>(() =>
            {
                var circularDependency = container.GetInstance<ISimpleCircularDependency2>();
            });
            Assert.Equal(3, cycleError1.Cycle.Count);
            Assert.Equal(typeof(SimpleCircularDependency2), cycleError2.Cycle[0]);
            Assert.Equal(typeof(SimpleCircularDependency1), cycleError2.Cycle[1]);
            Assert.Equal(typeof(SimpleCircularDependency2), cycleError2.Cycle[2]);
        }

        [Fact]
        public void ComplexCircularDependency()
        {
            //ARRANGE
            var config = new BindingConfig();
            config.Register<IComplexCircularDependency1, ComplexCircularDependency1>();
            config.Register<IComplexCircularDependency2, ComplexCircularDependency2>();
            config.Register<IComplexCircularDependency3, ComplexCircularDependency3>();
            var container = new Container(config);

            //ACT
            //ASSERT
            var cycleError1 = Assert.Throws<CircularDependencyException>(() =>
            {
                var circularDependency = container.GetInstance<IComplexCircularDependency1>();
            });
            Assert.Equal(4, cycleError1.Cycle.Count);
            Assert.Equal(typeof(ComplexCircularDependency1), cycleError1.Cycle[0]);
            Assert.Equal(typeof(ComplexCircularDependency2), cycleError1.Cycle[1]);
            Assert.Equal(typeof(ComplexCircularDependency3), cycleError1.Cycle[2]);
            Assert.Equal(typeof(ComplexCircularDependency1), cycleError1.Cycle[3]);

            var cycleError2 = Assert.Throws<CircularDependencyException>(() =>
            {
                var circularDependency = container.GetInstance<IComplexCircularDependency2>();
            });
            Assert.Equal(4, cycleError2.Cycle.Count);
            Assert.Equal(typeof(ComplexCircularDependency2), cycleError2.Cycle[0]);
            Assert.Equal(typeof(ComplexCircularDependency3), cycleError2.Cycle[1]);
            Assert.Equal(typeof(ComplexCircularDependency1), cycleError2.Cycle[2]);
            Assert.Equal(typeof(ComplexCircularDependency2), cycleError2.Cycle[3]);

            var cycleError3 = Assert.Throws<CircularDependencyException>(() =>
            {
                var circularDependency = container.GetInstance<IComplexCircularDependency3>();
            });
            Assert.Equal(4, cycleError3.Cycle.Count);
            Assert.Equal(typeof(ComplexCircularDependency3), cycleError3.Cycle[0]);
            Assert.Equal(typeof(ComplexCircularDependency1), cycleError3.Cycle[1]);
            Assert.Equal(typeof(ComplexCircularDependency2), cycleError3.Cycle[2]);
            Assert.Equal(typeof(ComplexCircularDependency3), cycleError3.Cycle[3]);
        }
    }
}