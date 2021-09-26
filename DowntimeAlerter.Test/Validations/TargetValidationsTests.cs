using Microsoft.VisualStudio.TestTools.UnitTesting;
using DowntimeAlerter.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DowntimeAlertereAlerter.Application.Exceptions;
using DowntimeAlerter.Domain.Entities;

namespace DowntimeAlerter.Application.Validations.Tests
{
    [TestClass()]
    public class TargetValidationsTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NotFoundException))]
        public void TestThrowException_NullTarget_IsTargetExistTest()
        {
            var targetValidation = new TargetValidations();
            targetValidation.IsTargetExist(1, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotFoundException))]
        public void TestThrowException_NotSameIds_IsTargetExistTest()
        {
            var targetValidation = new TargetValidations();
            
            var target = new Target()
            {
                Id = 1,
                Name = "test",
            };
            targetValidation.IsTargetExist(2, target);
        }

        [TestMethod()]
        public void TestTrue_IsTargetExistTest()
        {
            var targetValidation = new TargetValidations();
            var id = 1;
            var target = new Target()
            {
                Id = id,
                Name = "test",
            };
            targetValidation.IsTargetExist(id, target);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotAuthorizedException))]
        public void TestThrowException_IsTargetAuthorized()
        {
            var targetValidation = new TargetValidations();
            var target = new Target()
            {
                Name = "test",
                CreatedBy = "test"
            };
            targetValidation.IsTargetAuthorized(1, null, "test");
        }

        [TestMethod()]
        public void TestTrue_IsTargetAuthorized()
        {
            var targetValidation = new TargetValidations();
            var target = new Target()
            {
                Name = "test",
                CreatedBy = "test"
            };
            targetValidation.IsTargetAuthorized(1, target, "test");
        }
    }
}